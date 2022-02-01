using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons_Select6 : MonoBehaviour
{
    private GameObject buttons_select6;

    void Start()
    {
        buttons_select6 = GameObject.Find("Button_Model6");
        buttons_select6.GetComponent<Button>().onClick.AddListener(Button_Model6_OnClick);
    }

    void Button_Model6_OnClick()
    {
        string Button_Name_Recover = "Button_Model" + Init.MainConfig.slot.ToString();
        GameObject ButtonNeedRecover = GameObject.Find(Button_Name_Recover);
        ButtonNeedRecover.GetComponent<Image>().color = Color.white;//֮ǰ�ı��

        this.GetComponent<Image>().color = Color.green;//���ڵı���
        ChangeConfigText.UpdateConfigText();
        Init.MainConfig.slot = 6;
    }

}
