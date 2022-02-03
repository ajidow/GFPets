using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowModeInit : MonoBehaviour
{
    private void ModelsInit()
    {
        for (int i = 1; i < 10; ++i)
        {
            if (Init.MainConfig.isEmpty[i] == false)
            {
                CreateAndDeleteModel.CreateModelFromFile(ref Init.MainConfig, i);
                string NewGameObject = "Model" + i.ToString();
                GameObject neo = GameObject.Find(NewGameObject);
                int x = Init.MainConfig.config[i].screenX;
                int y = Init.MainConfig.config[i].screenY;
                float scale = Init.MainConfig.config[i].scale;
                neo.transform.position = new Vector3(0,-50,0);
                neo.transform.localScale = new Vector3(scale,scale, 0f);
            }
        }
    }
    private void CameraInit()
    {
        Camera cam = GetComponent<Camera>();
        cam.orthographicSize = Screen.height / 2;
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);
    }
    void Start()
    {
        CameraInit();
        ModelsInit();
    }
}