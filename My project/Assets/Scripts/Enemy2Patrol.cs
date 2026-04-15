// Title: Enemy Patrolling Unity Tutorial
// Author: MoreBBlakeyyy
// Date: 14 October 2022
// Availability: https://www.youtube.com/watch?v=4mzbDk4Wsmk 
using UnityEngine;

public class Enemy2Patrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint;
    [SerializeField]
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
