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

//Title: AudioSource.Pause
//Author: Unity Documentation
//Date: 28 April 2026
//Code version: Unity 6000.4
//Availability: https://docs.unity3d.com/ScriptReference/AudioSource.Pause.html

//Title: AudioSource.UnPause
//Author: Unity Documentation
//Date: 28 April 2026
//Code version: Unity 6000.4
//https://docs.unity3d.com/ScriptReference/AudioSource.UnPause.html 
using UnityEngine;

public class DogBark : MonoBehaviour
{
    AudioSource source; 
    Collider2D soundTrigger; //name collider component

    bool gameOver = false;

    bool IsPlayerInTrigger = false;

    void Awake()
    {
        source = GetComponent<AudioSource>(); //get the audio source
        soundTrigger = GetComponent<Collider2D>(); //get the collider
    }

    void OnEnable() //refers to game over function
    {
        PlayerHealth.OnPlayerDeath += HandleGameOver;
    }

    void OnDisable() //refers to game over function
    {
        PlayerHealth.OnPlayerDeath -= HandleGameOver;
    }

    void HandleGameOver()
    {
        gameOver = true;
        source.Stop(); //if the player dies, stop playing the audio
    }
   void OnTriggerEnter2D(Collider2D collider) //if another collider enters
    {
        if (gameOver) //exit function if the game is over
        {
            return;
        }
        
        if (collider.CompareTag("Player")) //if collider that enters has the 'player' tag
        {
            IsPlayerInTrigger = true;

            if (!PauseMenu.GameIsPaused && !source.isPlaying)
            {
                source.Play(); //play audio source
            }
        }

    }

    void OnTriggerExit2D(Collider2D collider) //if player exits, stop playing the audio
    {
        if (collider.CompareTag("Player"))
        {
            IsPlayerInTrigger = false;
            source.Stop();
        }
    }

    void Update()
    {
        if(PauseMenu.GameIsPaused)
        {
            if (source.isPlaying)
            {
                source.Pause();
            }
        }
        else
        {
            if (!source.isPlaying && IsPlayerInTrigger)
            {
                source.UnPause();
            }
        }
    }
}
