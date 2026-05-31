using UnityEngine;
using UnityEngine.SceneManagement;

//Title: GAME OVER Menu In Unity Tutorial
//Author: BMo
//Date: 17 March 2022
//Code version: Unity 2020.3.22f1
//Availability: https://www.youtube.com/watch?v=ZfRbuOCAeE8

//Title: PAUSE MENU in Unity
//Author: Brackeys
//Date: 20 December 2017
//Code version: Unity 2017.2.0f3
//Availability: https://www.youtube.com/watch?v=JivuXdrIHK0 

public class WinMenu : MonoBehaviour
{
    public GameObject winMenu;

    internal static object instance;

    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //restart the scene that is currently active
    }

    public void TitleScreen()
    {
        Time.timeScale = 1f;
        //GameStateManager.Instance.ResumeGame();
        SceneManager.LoadScene("Start Menu");
    }
 
}
