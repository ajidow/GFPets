using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Json_Operation : MonoBehaviour
{
    public static bool ReadJson(string filePath)
    {
        if(!File.Exists(filePath))
        {
            Debug.Log("not exist");
            return false;
        }
        string jsonText = File.ReadAllText(filePath);
        var jsonData = new Model_Config.Config();
        jsonData = JsonUtility.FromJson<Model_Config.Config>(jsonText);

        
        return true;
    }

    public static bool WriteJson(string filePath)
    {
        return true;
    }
}
