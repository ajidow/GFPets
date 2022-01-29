using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Button_Load : MonoBehaviour
{
    private GameObject button_load;
    void Start()
    {
        button_load = GameObject.Find("Button_Load");
        button_load.GetComponent<Button>().onClick.AddListener(Button_Load_OnClick);
        
    }

    void Button_Load_OnClick()
    {
        string filePath;
        filePath = Open_File_Dialog.OpenFileDialog();//����ѡ���ļ���� Win32API=>Open_File_Dialog=>Button_Load
        
        if(filePath == null)
        {
            //���ļ�ʧ��
        }
        else
        {
            Read_Json.ReadJson(filePath);//json����
        }


    }    
}
