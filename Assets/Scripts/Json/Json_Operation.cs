using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using static Model_Config;

public class Json_Operation : MonoBehaviour
{
    public static bool ReadJson(string filePath,ref Config cfg)
    {
        if(!File.Exists(filePath))
        {
            Debug.Log("not exist");
            return false;
        }
        string jsonText = File.ReadAllText(filePath);
        
        cfg = JsonUtility.FromJson<Model_Config.Config>(jsonText);
        if(cfg.screenX == -1)
        {
            cfg.screenX = Screen.width;
        }
        if(cfg.screenY == -1)
        {
            cfg.screenY = Screen.height;
        }
        return true;
    }

    public static bool WriteJson(string filePath,ref Config cfg)
    {
        if(!File.Exists(filePath))
        {
            File.Create(filePath);
        }
        string jsonText = JsonUtility.ToJson(cfg,true);
        File.WriteAllText(filePath, jsonText);
        return true;
    }
   
}
