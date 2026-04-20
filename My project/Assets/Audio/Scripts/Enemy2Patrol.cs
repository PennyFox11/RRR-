// Title: Enemy Patrolling Unity Tutorial
// Author: MoreBBlakeyyy
// Date: 14 October 2022
//Code version: Unity 2020.3.25f1
// Availability: https://www.youtube.com/watch?v=4mzbDk4Wsmk 

//Title: OnTriggerEnter/OnTriggerExit mechanics
//Author: Unity Discussions
//Date: June 2021
//Availability: https://discussions.unity.com/t/ontriggerenter-ontriggerexit-mechanics/844873 
using UnityEngine;

public class Enemy2Patrol : MonoBehaviour
{
    public Transform[] patrolPoints; //array of game objects that are the patrol points
    public int targetPoint; //which patrol point enemy must go to next
    [SerializeField]
    public float speed; //speed of enemy (adjust in inspector)

    public bool isPaused = false; //patrol is currently not paused
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPoint = 0; //start at zero
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused) //exit the function if the patrol is paused
        {
            return;
        }
        
        if(transform.position == patrolPoints[targetPoint].position) //if enemy reaches target position
        {
            increaseTargetInt(); //call method
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime); //move from current position to target position at a constant speed
    }

    void increaseTargetInt() 
    {
        targetPoint++; //increment target point value by 1
        if(targetPoint >= patrolPoints.Length) //if new target point is outside bounds of array
        {
            targetPoint = 0; //return to start
        }
    }
}
