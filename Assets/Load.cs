using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        data.highscore = pm.score;
    }
    public void LoadData(PlayerSaveData data)
    {

    }



    
}
[System.Serializable]
public struct PlayerSaveData
{

    public int highscore;

}