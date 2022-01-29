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
        filePath = Save_File_Dialog.SaveFileDialog(); //���������ļ���� Win32API=>Save_File_Dialog=>Button_Save
        if(filePath == null)
        {
            //�����ļ�ʧ��
        }
        else
        {
            
            //Json_Operation.WriteJson(filePath);
            
        }
    }
}
