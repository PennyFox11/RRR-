using UnityEngine;
using UnityEngine.SceneManagement;
//https://www.youtube.com/watch?v=8kVeDbuqokU 

public class ReturnButton : MonoBehaviour
{
    public void OnReturnButton()
    {
        SceneManager.LoadScene(0);
    }

}
