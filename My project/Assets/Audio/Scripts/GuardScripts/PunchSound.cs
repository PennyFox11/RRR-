//Title: Play Sound Effects on Trigger Events ~ Unity 2022.1 Tutorial
//Author: Chris' Tutorials
//Date: 10 October 2022
//Code version: Unity 2022.1.19f1
//Availability: https://www.youtube.com/watch?v=E7-HAJ4Db64
using UnityEngine;

public class PunchSound : MonoBehaviour
{
    AudioSource source; //reference audio source component
    Collider2D soundTrigger; //reference the collider which triggers the sound

    void Awake()
    {
        source = GetComponent<AudioSource>(); //reference/get the audio source
        soundTrigger = GetComponent<Collider2D>(); //reference/get the collider trigger component
    }
   
   void OnTriggerEnter2D(Collider2D collider) //if you have a collider 2D shape added to your game object, this function will be called when that game object enters the trigger collider (layer collisions)
    {
        if (collider.gameObject.tag == "Player") //if the collider is the player (has the "Player" tag)
        {
            source.Play(); //sound plays
        }
    }
}
