//Title: Play Sound Effects on Trigger Events ~ Unity 2022.1 Tutorial
//Author: Chris' Tutorials
//Date: 10 October 2022
//Code version: Unity 2022.1.19f1
//Availability: https://www.youtube.com/watch?v=E7-HAJ4Db64

//Title: AudioSource
//Author: Unity Documentation
//Date: 17 April 2026
//Code version: Unity 6000.4
//Availability: https://docs.unity3d.com/ScriptReference/AudioSource.html
using UnityEngine;

public class DogBark : MonoBehaviour
{
    AudioSource source;
    Collider2D soundTrigger;

    bool gameOver = false;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        soundTrigger = GetComponent<Collider2D>();
    }

    void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += HandleGameOver;
    }

    void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= HandleGameOver;
    }

    void HandleGameOver()
    {
        gameOver = true;
        source.Stop();
    }
   void OnTriggerEnter2D(Collider2D collider)
    {
        if (gameOver)
        {
            return;
        }
        
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
