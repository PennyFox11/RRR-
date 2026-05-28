using UnityEngine;

public class OverallGameManager : MonoBehaviour
{
    public static OverallGameManager Instance;

    public float masterVolume = 0.5f;
    public float brightness = 0.5f;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

        private void Start()
    {
        masterVolume = PlayerPrefs.GetFloat("Volume", 0.5f);

        AudioListener.volume = masterVolume;
    }

}
