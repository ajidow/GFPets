using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons_Select8 : MonoBehaviour
{
    private GameObject buttons_select8;

    void Start()
    {
        buttons_select8 = GameObject.Find("Button_Model8");
        buttons_select8.GetComponent<Button>().onClick.AddListener(Button_Model8_OnClick);
    }

    void Button_Model8_OnClick()
    {
        string Button_Name_Recover = "Button_Model" + Init.MainConfig.slot.ToString();
        GameObject ButtonNeedRecover = GameObject.Find(Button_Name_Recover);
        ButtonNeedRecover.GetComponent<Image>().color = Color.white;//之前的变白

        this.GetComponent<Image>().color = Color.green;//现在的变绿
        ChangeConfigText.UpdateConfigText();
        Init.MainConfig.slot = 8;
    }

}
