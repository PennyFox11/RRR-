using UnityEngine;
using UnityEngine.SceneManagement;
//Title: PAUSE MENU in Unity
//Author: Brackeys
//Date: 20 December 2017
//Code version: Unity 2017.2.0f3
//Availability: https://www.youtube.com/watch?v=JivuXdrIHK0 
public class PauseMenu : MonoBehaviour
{
  public GameObject pauseMenuUI;

  public static bool GameIsPaused;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameStateManager.Instance.isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        GameStateManager.Instance.ResumeGame();

        
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
        GameStateManager.Instance.PauseGame();
    }

    public void Quit()
    {
        GameStateManager.Instance.ResumeGame();
        SceneManager.LoadScene("Start Menu");
    }

    public void Settings()
    {
        pauseMenuUI.SetActive(false);
        SceneManager.LoadScene(
            "Settings", 
            LoadSceneMode.Additive
            );  
    }
}
