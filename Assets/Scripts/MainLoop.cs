using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLoop : MonoBehaviour
{
    private ShowModeLoop loop;
    void Start()
    {
        loop = new ShowModeLoop(ref Init.MainConfig);
        loop.loopInit();
    }

    // Update is called once per frame
    void Update()
    {
        loop.checkHit();
    }
}
