//Title: Menu UI with Tab Switching - Top Down Unity 2D #6
//Author: Game Code Library 
//Date: 4 September 2024
//Code Version: Unity 2022.3.20f1 LTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuCanvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        menuCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) //click tab to exit menu page
        {
            if (!menuCanvas.activeSelf && PauseController.IsGamePaused) //halt dialogue or anything else from continuing if game is paused
            {
                return;
            }
            menuCanvas.SetActive(!menuCanvas.activeSelf);
            PauseController.SetPause(menuCanvas.activeSelf);
        }
    }
}
