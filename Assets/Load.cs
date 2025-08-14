
using UnityEngine;

public class Load : MonoBehaviour
{
    public PlayerMovement pm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private static Load instance;
    public static Load Instance
    {
        get
        {
            if (!Application.isPlaying)
            {
                return null;
            }
            if (instance == null)
            {
                Instantiate(Resources.Load<Load>("Load"));


            }
            return instance;
        }
    }
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    public void Save(ref PlayerSaveData data)
    {
        if (StaticData.difficulty==1)
        {
            if(data.easyhighscore>pm.score)
            data.easyhighscore = pm.score;
        }
        if(StaticData.difficulty == 2)
        {
            if (data.mediumhighscore > pm.score)
                data.mediumhighscore = pm.score;
        }
        if(StaticData.difficulty == 3)
        {
            if (data.hardhighscore > pm.score)
                data.hardhighscore = pm.score;
        }
    }
    public void LoadData(PlayerSaveData data)
    {

    }



    
}
[System.Serializable]
public struct PlayerSaveData
{

    public int easyhighscore;
    public int mediumhighscore;
    public int hardhighscore;

}