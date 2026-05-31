using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeButton : MonoBehaviour
{

    public void Resume()
    {
        GameStateManager.Instance.ResumeGame();
        GameStateManager.Instance.LoadGameScene();

    }

}
