using UnityEngine;
using UnityEngine.SceneManagement;
//Title: PAUSE MENU in Unity
//Author: Brackeys
//Date: 20 December 2017
//Code version: Unity 2017.2.0f3
//Availability: https://www.youtube.com/watch?v=JivuXdrIHK0 
public class PauseMenu : MonoBehaviour
{
  public static bool GameIsPaused = false;

  public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
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
        Time.timeScale = 1f;
        GameIsPaused = false;
        
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("Start Menu");
    }
}
