using UnityEngine;

public class MusicZone : MonoBehaviour
{
    public AudioClip roomMusic;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.PlayMusic(roomMusic);
        }
    }
}