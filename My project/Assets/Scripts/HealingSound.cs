//Title: Play Sound Effects on Trigger Events ~ Unity 2022.1 Tutorial
//Author: Chris' Tutorials
//Date: 10 October 2022
// Code version: Unity 2022.1.19f1
//Availability: https://www.youtube.com/watch?v=E7-HAJ4Db64 
using UnityEngine;

public class HealingSound : MonoBehaviour
{
    AudioSource source;
    Collider2D soundTrigger;

    void Awake()
    {
        source = GetComponent<AudioSource>(); //get the audio source component
        soundTrigger = GetComponent<Collider2D>(); //get the collider component
    }
   
   void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player") // if a game object with the "player" tag enters the collider
        {
            source.Play(); //play audio
        }
    }
}
