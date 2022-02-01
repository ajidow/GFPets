using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeConfigText
{
    public static void  UpdateConfigText()
    {
        GameObject name = GameObject.Find("Text_Name");
        name.GetComponent<Text>().text = Init.MainConfig.config[Init.MainConfig.slot].name;
    }
}
