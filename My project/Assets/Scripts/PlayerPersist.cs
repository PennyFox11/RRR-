using UnityEngine;

public class PlayerPersist : MonoBehaviour
{
    private void Awake()
    {
        // Prevent duplicates if returning to a scene that has another Player
        if(FindObjectsOfType<PlayerPersist>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}