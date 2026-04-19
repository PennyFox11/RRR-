//Title: OnTriggerEnter/OnTriggerExit mechanics
//Author: Unity Discussions
//Date: June 2021 
//Availability: https://discussions.unity.com/t/ontriggerenter-ontriggerexit-mechanics/844873
using UnityEngine;

public class DogDetection : MonoBehaviour
{
    private Enemy2Patrol patrolScript; //refer to enemy's movement
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        patrolScript = GetComponentInParent<Enemy2Patrol>(); //get this script
    }

    void OnTriggerEnter2D(Collider2D other) //if player enters the collider, pause the patrol
    {
        if(other.CompareTag("Player"))
        {
            patrolScript.isPaused = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)//if player exits the collider, resume the patrol
    {
        if (other.CompareTag("Player"))
        {
            patrolScript.isPaused = false;
        }
    }
}
