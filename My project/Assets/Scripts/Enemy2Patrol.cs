// Title: Enemy Patrolling Unity Tutorial
// Author: MoreBBlakeyyy
// Date: 14 October 2022
// Availability: https://www.youtube.com/watch?v=4mzbDk4Wsmk 

//Title: OnTriggerEnter/OnTriggerExit mechanics
//Author: Unity Discussions
//Date: June 2021
//Availability: https://discussions.unity.com/t/ontriggerenter-ontriggerexit-mechanics/844873 
using UnityEngine;

public class Enemy2Patrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint;
    [SerializeField]
    public float speed;

    public bool isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            return;
        }
        
        if(transform.position == patrolPoints[targetPoint].position)
        {
            increaseTargetInt();
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);
    }

    void increaseTargetInt()
    {
        targetPoint++;
        if(targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }
    }
}
