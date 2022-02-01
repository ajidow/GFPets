using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons_Select4 : MonoBehaviour
{
    private GameObject buttons_select4;

    void Start()
    {
        buttons_select4 = GameObject.Find("Button_Model4");
        buttons_select4.GetComponent<Button>().onClick.AddListener(Button_Model4_OnClick);
    }

    void Button_Model4_OnClick()
    {
        string Button_Name_Recover = "Button_Model" + Init.MainConfig.slot.ToString();
        GameObject ButtonNeedRecover = GameObject.Find(Button_Name_Recover);
        ButtonNeedRecover.GetComponent<Image>().color = Color.white;//之前的变白

        this.GetComponent<Image>().color = Color.green;//现在的变绿
        Init.MainConfig.slot = 4;
    }

}
