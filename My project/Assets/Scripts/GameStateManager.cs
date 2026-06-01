//Title: Implement data persistence between scenes (this script is partially based off teh Unity Learn one, with modifications)
//Author: Unity Learn
//Date: 2026
//Code version: Unity 6.0
//Availability: https://learn.unity.com/tutorial/implement-data-persistence-between-scenes

//Title: Application.Quit
//Author: Unity Documentation
//Date: 30 May 2026
//Code version: Unity 6000.4
//Availability: https://docs.unity3d.com/6000.4/Documentation/ScriptReference/Application.Quit.html

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    public bool isPaused = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("boss level");
    }

    public void QuitGame() //allows you to exit game completely in build
    {
        Debug.Log("Quitting Game");

        Time.timeScale = 1f; //safety reset
        Application.Quit();
    }

}
