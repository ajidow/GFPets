using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Read_Json : MonoBehaviour
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
}
