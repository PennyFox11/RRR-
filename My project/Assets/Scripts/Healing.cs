//Title: Create a health collectible using triggers
//Author: Unity Learn
//Date: 2026
//Code version: Unity 6000.3.8f1
//Availability: https://learn.unity.com/course/2D-adventure-robot-repair/unit/health-system/tutorial/create-a-health-collectible-using-triggers?version=6.3
using UnityEngine;

public class Healing : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) //calls his function when the physics system detects a game object with a rigidbody component hitting another game object with a collider component that is a trigger and has a script attached to it. "Other" = Reference the collider component that entered teh trigger
    {
        PlayerHealth health = other.GetComponent<PlayerHealth>(); //find the player with the Player Health script attached to it

        if (health != null) //if health exists/is not zero
        {
            health.ChangeHealth(60); //increase Player Health by 60
            Debug.Log("Player health has increased by 60");
        }
    }
}

