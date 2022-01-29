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
            return false;
        }
        string jsonText = File.ReadAllText(filePath);
        
        return true;
    }

    public static bool WriteJson(string filePath)
    {
        return true;
    }
}
