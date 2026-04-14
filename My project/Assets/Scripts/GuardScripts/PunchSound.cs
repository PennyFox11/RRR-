//https://www.youtube.com/watch?v=E7-HAJ4Db64
using UnityEngine;

public class PunchSound : MonoBehaviour
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
        if (collider.gameObject.tag == "Player")
        {
            source.Play();
        }
    }
}
