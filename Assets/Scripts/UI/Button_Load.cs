using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using SFB;

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
        var filePath = StandaloneFileBrowser.OpenFilePanel("Open File", "", "json", true);
        Json_Operation.ReadJson(filePath[0],ref Init.MainConfig.config[Init.MainConfig.slot]);

    }    
}
