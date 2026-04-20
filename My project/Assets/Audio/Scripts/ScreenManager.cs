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
