using UnityEngine;
using UnityEngine.SceneManagement;
//Title: How to Create a Start Menu in Unity
//Author: Zenva
//Date: 8 January 2023
//Code version: Unity 2021.3.1f1
//Availability: https://www.youtube.com/watch?v=8kVeDbuqokU 

public class StartMenu : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OnTutorialButton()
    {
        SceneManager.LoadScene(2);
    }

}
