//Title: GAME OVER Menu In Unity Tutorial
//Author: BMo
//Date: 17 March 2022
//Code version: 2020.3.22f1
//Availability: https://www.youtube.com/watch?v=ZfRbuOCAeE8
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += EnableGameOverMenu;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= EnableGameOverMenu;
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
