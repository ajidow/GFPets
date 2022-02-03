using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Spine.Unity;

public class Button_Start : MonoBehaviour
{
    private GameObject button_start;
    void Start()
    {
        button_start = GameObject.Find("Button_Start");
        button_start.GetComponent<Button>().onClick.AddListener(Button_Start_OnClick);
    }

    void Button_Start_OnClick()
    {   
        SceneManager.LoadScene("ShowMode");   
    }
}
