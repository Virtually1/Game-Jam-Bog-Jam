using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.Loading;

public class SaveSystem 
{

    private static SaveData savedata = new SaveData();
    [System.Serializable]
    public struct SaveData
    {
        public PlayerSaveData PSD;

    }
    public static string GetSavePath(int slot)
    {
        string path = Application.persistentDataPath + "/save"+slot.ToString()+".gmsf";
        return path;
    }
    public static void Save(int slot)
    {
        HSD();  
        File.WriteAllText(GetSavePath(slot), JsonUtility.ToJson(savedata));
    }
    public static void HSD()
    {
        Load.Instance.Save(ref savedata.PSD);
    }
    public static void Loads(int slot)
    {
        string Content = File.ReadAllText(GetSavePath(slot));
        savedata = JsonUtility.FromJson<SaveData>(Content);
        HLD();
    }
    public static void HLD()
    {
        Load.Instance.LoadData(savedata.PSD);
    }
}

