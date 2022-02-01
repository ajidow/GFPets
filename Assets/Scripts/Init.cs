using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    public static Model_Config MainConfig;
    void Awake()
    {
        MainConfig = new Model_Config();
    }
}
