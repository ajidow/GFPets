using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using SFB;

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
        var filePath = StandaloneFileBrowser.SaveFilePanel("Save File", "", "", "json");
        Json_Operation.WriteJson(filePath, ref Init.MainConfig.config[Init.MainConfig.slot]);
    }
}
