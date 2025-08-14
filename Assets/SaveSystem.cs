
using UnityEngine;
using System.IO;

public class SaveSystem 
{

    private static SaveData savedata = new SaveData();
    [System.Serializable]
    public struct SaveData
    {
        public PlayerSaveData PSD;

    }
    public static string GetSavePath()
    {
        string path = Application.persistentDataPath + "/save"+".gmsf";
        return path;
    }
    public static void Save()
    {
        HSD();  
        File.WriteAllText(GetSavePath(), JsonUtility.ToJson(savedata));
    }
    public static void HSD()
    {
        Load.Instance.Save(ref savedata.PSD);
    }
    public static void Loads()
    {
        string Content = File.ReadAllText(GetSavePath());
        savedata = JsonUtility.FromJson<SaveData>(Content);
        HLD();
    }
    public static void HLD()
    {
        Load.Instance.LoadData(savedata.PSD);
    }
}

