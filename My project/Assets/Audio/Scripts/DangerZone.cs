//Title: Add damage zones to decrease health (static hazards)
//Author: Unity Learn
//Date: 2026
//Code version: Unity 6000.3.8f1
//Availability: https://learn.unity.com/course/2D-adventure-robot-repair/unit/health-system/tutorial/add-damage-zones-to-decrease-health-static-hazards?version=6.3//
using UnityEngine;
using UnityEngine.EventSystems;

public class DangerZone : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    AudioSource source; //refer to the audio source component
    bool playerDead = false;
    bool IsAttacking = false;

    void Awake()
    {
        source = GetComponent<AudioSource>(); //get the audio source component

        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable() //refers to game over function
    {
        PlayerHealth.OnPlayerDeath += HandlePlayerDeath;
    }

    void OnDisable() //refers to game over function
    {
        PlayerHealth.OnPlayerDeath -= HandlePlayerDeath;
    }

    void HandlePlayerDeath() //if the player "dies", stop playing the audio
    {
        playerDead = true;
        source.Stop();
    }

    public void OnTriggerStay2D(Collider2D other) //player stays in danger zone collider
    {
        if (playerDead) //exit teh function if the player is dead
        {
            return;
        }

        PlayerHealth health = other.GetComponent<PlayerHealth>(); //get the player's health

        if (health != null) //health exists/is not zero
        {
            health.ChangeHealth(-10); //decrease player health by 10

            if(!source.isPlaying) 
            {
                source.Play(); //play attack sound
                
            }
        }

        anim.SetBool("IsAttacking", IsAttacking);
        IsAttacking = true;
    }
}
