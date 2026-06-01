//Title: Unity - Code Audio to Play When Entering an Area
//Author: Ryan Murray
//Date: 12 May 2022
//Code version: Unity 2020.3.32f1
//Availability: https://www.youtube.com/watch?v=x2qiWGcLku0

//this was also adapted from the diamond glimmer effect animation scripts
using UnityEngine;

public class diamondsound : MonoBehaviour
{
    public AudioSource source;
    private bool hasPlayed = false; //set up bool so player is only detected once
    
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.CompareTag("Player") && !hasPlayed) //if player hits trigger for the first time
        {
            hasPlayed = true; //mark that player has eneterd once
            if (!source.isPlaying)
            {
                source.Play();
            }
        }
    }



}
