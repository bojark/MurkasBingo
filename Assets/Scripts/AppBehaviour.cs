﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppBehaviour : MonoBehaviour
{



    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        };
        
    }

    public void Exit()
    {
        Application.Quit();
    }
}
