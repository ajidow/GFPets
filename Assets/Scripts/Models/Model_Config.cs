using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model_Config
{
    [SerializeField]
    public class Config
    {
        public string name;
        public string initialStatus;
        public int VelocityOfMovementX;
        public int VelocityOfMovementY;
        public int BlackZoneStartX;
        public int BlackZoneStartY;
        public int BlackZoneEndX;
        public int BlackZoneEndY;
        public string JsonFilePath;
        public string AtlasFilePath;
        public string Texture2DPath;
    }// test.json
    public int slot;
    public Config[] config;

    public Model_Config()
    {
        slot = 1;
        config = new Config[10];
    }
}
