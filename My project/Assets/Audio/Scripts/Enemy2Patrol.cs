// Title: Enemy Patrolling Unity Tutorial
// Author: MoreBBlakeyyy
// Date: 14 October 2022
//Code version: Unity 2020.3.25f1
// Availability: https://www.youtube.com/watch?v=4mzbDk4Wsmk 

//Title: OnTriggerEnter/OnTriggerExit mechanics
//Author: Unity Discussions
//Date: June 2021
//Availability: https://discussions.unity.com/t/ontriggerenter-ontriggerexit-mechanics/844873 

//Title:
//Author:
//Date:
//Code version:
//Availability: https://docs.unity3d.com/Manual/AnimationParameters.html

//Title:
//Author:
//Date:
//Code version:
//Availability: https://docs.unity3d.com/ScriptReference/Vector3.Distance.html

//Title:
//Author:
//Date:
//Code version:
//Availability: https://docs.unity3d.com/6000.4/Documentation/ScriptReference/Vector3-normalized.html 

//Title:
//Author:
//Date:
//Code version:
//Availability: https://docs.unity3d.com/Manual/class-BlendTree.html 
using UnityEngine;

public class Enemy2Patrol : MonoBehaviour
{
    public Transform[] patrolPoints; //array of game objects that are the patrol points
    public int targetPoint; //which patrol point enemy must go to next
    [SerializeField]
    public float speed; //speed of enemy (adjust in inspector)

    public bool isPaused = false; //patrol is currently not paused
    public Animator animator;
    private Vector2 movementDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetPoint = 0; //start at zero
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused) //exit the function if the patrol is paused
        {
            animator.SetBool("isMoving", false);
            return;
        }
        
        Vector3 target = patrolPoints[targetPoint].position;
        
        movementDirection = (target - transform.position).normalized;

        animator.SetFloat("MoveX", movementDirection.x);
        animator.SetFloat("MoveY", movementDirection.y);

        animator.SetFloat("LastMoveX", movementDirection.x);
        animator.SetFloat("LastMoveY", movementDirection.y);

        animator.SetBool("isMoving", true);

        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target) < 0.05f)
        {
            increaseTargetInt();
        }
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
