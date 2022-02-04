using Spine.Unity;
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
        public string TextureName;
        public int screenX;
        public int screenY;
        public float scale;
        public string[] ClickAnimationName;
        public string DragAnimationName;
        public string SleepAnimationName;
        public string MoveAnimationName;
        public float TransitionTime;
    }// test.json
    public int slot;
    public Config[] config;
    public DataAssetsFromExports[] Models;
    public bool[] isOpen;
    public bool[] isEmpty;
    public int[] ModelClickMotionNumber;
    public Model_Config()
    {
        slot = 1;
        config = new Config[10];
        Models = new DataAssetsFromExports[10];
        isOpen = new bool[10];
        isEmpty = new bool[10];
        ModelClickMotionNumber = new int[10];


        for (int i = 0; i < 10; ++i)
        {
            isOpen[i] = false;
            isEmpty[i] = true;
            ModelClickMotionNumber[i] = 0;
        }
    }
}
