////https://www.youtube.com/watch?v=E7-HAJ4Db64
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
   
   void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            source.Play();
        }
    }
}
