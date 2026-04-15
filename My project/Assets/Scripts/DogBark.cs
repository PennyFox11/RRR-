//https://www.youtube.com/watch?v=E7-HAJ4Db64
//https://docs.unity3d.com/ScriptReference/AudioSource.html
using UnityEngine;

public class DogBark : MonoBehaviour
{
    AudioSource source;
    Collider2D soundTrigger;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        soundTrigger = GetComponent<Collider2D>();
    }
   
   void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (!source.isPlaying)
            {
                source.Play();
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            source.Stop();
        }
    }
}
