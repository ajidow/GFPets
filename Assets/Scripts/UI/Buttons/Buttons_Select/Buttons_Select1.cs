using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons_Select1 : MonoBehaviour
{
    private GameObject buttons_select1;

    void Start()
    {
        buttons_select1 = GameObject.Find("Button_Model1");
        buttons_select1.GetComponent<Button>().onClick.AddListener(Button_Model1_OnClick);
    }

    void Button_Model1_OnClick()
    {
        string Button_Name_Recover = "Button_Model" + Init.MainConfig.slot.ToString();//大标题改一改
        GameObject ButtonNeedRecover = GameObject.Find(Button_Name_Recover);
        ButtonNeedRecover.GetComponent<Image>().color = Color.white;//之前的变白

        this.GetComponent<Image>().color = Color.green;//现在的变绿

        Init.MainConfig.slot = 1;
        ChangeConfigText.UpdateConfigText();//刷新大名
        
    }

}
