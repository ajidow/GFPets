using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Stop : MonoBehaviour
{
    private GameObject button_stop;
    void Start()
    {
        button_stop = GameObject.Find("Button_Stop");
        button_stop.GetComponent<Button>().onClick.AddListener(Button_Stop_OnClick);
    }

    void Button_Stop_OnClick()
    {
        GameObject GameObjectDestory = GameObject.Find("New Spine GameObject");
        if (Init.MainConfig.isOpen[Init.MainConfig.slot])
        {
            Destroy(GameObjectDestory);
            Init.MainConfig.isOpen[Init.MainConfig.slot] = false;
        }
        else
            Debug.Log("nothing");
        
    }
}
