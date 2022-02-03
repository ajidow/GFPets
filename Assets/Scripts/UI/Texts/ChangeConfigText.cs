using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeConfigText
{
    public static void  UpdateConfigText()
    {
        GameObject name = GameObject.Find("Text_Name");
        if (Init.MainConfig.isEmpty[Init.MainConfig.slot])
        {
            name.GetComponent<Text>().text = "请打开文件";
        }
        else
        {
            name.GetComponent<Text>().text = Init.MainConfig.config[Init.MainConfig.slot].name;
        }
    }
}
