
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewStart : MonoBehaviour
{
    public bool[] has_save;
    public TextMeshProUGUI[] texts = new TextMeshProUGUI[3];
    public PlayerSaveData saveData = new PlayerSaveData();
    // Start is called before the first frame update
    void Start()
    {
        LoadIN();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Start(int slot)
    {
        bool isNew = true;
        StaticData.slotindex = slot;
        StaticData.difficulty = slot+1;
        SceneManager.LoadScene("Game");
    }
    public void LoadIN()
    {

            if(File.Exists(Application.persistentDataPath + "/save" + ".gmsf"))
            {
                if (File.ReadAllText(Application.persistentDataPath + "/save"+".gmsf") != null)
                {

                    SaveSystem.Loads();
                
                    texts[0].text = saveData.easyhighscore.ToString();
                    texts[1].text = saveData.mediumhighscore.ToString();
                    texts[1].text = saveData.hardhighscore.ToString();
                }
            }
        
    }
    public void Easy()
    {
        Start(0);
    }
    public void Medium()
    {
        Start(1);
    }
    public void Hard()
    {
        Start(2);
    }
}

