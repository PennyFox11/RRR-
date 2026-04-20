//Title: GAME OVER Menu In Unity Tutorial
//Author: BMo
//Date: 17 March 2022
//Code version: Unity 2020.3.22f1
//Availability: https://www.youtube.com/watch?v=ZfRbuOCAeE8
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    public GameObject WinScreen;

    void OnEnable()
    {
        PlayerInventory.OnKeyCollected += EnableWinScreen;
    }

    void OnDisable()
    {
        PlayerInventory.OnKeyCollected -= EnableWinScreen;
    }
        public void EnableWinScreen()
    {
        WinScreen.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
