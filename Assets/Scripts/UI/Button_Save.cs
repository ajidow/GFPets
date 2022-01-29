using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Button_Save : MonoBehaviour
{
    private GameObject button_save;
    void Start()
    {
        button_save = GameObject.Find("Button_Save");
        button_save.GetComponent<Button>().onClick.AddListener(Button_Save_OnClick);
    }

    void Button_Save_OnClick()
    {
        string filePath;
        filePath = Save_File_Dialog.SaveFileDialog(); //弹出保存文件框框 Win32API=>Save_File_Dialog=>Button_Save
        if(filePath == null)
        {
            //保存文件失败
        }
        else
        {
            
            //Json_Operation.WriteJson(filePath);
            
        }
    }
}
