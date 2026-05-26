//Title: GAME OVER Menu In Unity Tutorial
//Author: BMo
//Date: 17 March 2022
//Code version: Unity 2020.3.22f1
//Availability: https://www.youtube.com/watch?v=ZfRbuOCAeE8

//Title: Scripting Player Movement
//Author: Unity Learn
//Date: 2026
//Code version: Unity 6000.3.8f1
//Availability: https://learn.unity.com/course/using-the-input-system-in-unity/tutorial/scripting-player-movement-1?version=2020.1

using UnityEngine;
using UnityEngine.InputSystem; //allow for input

public class PlayerMove : MonoBehaviour
{
    //public float MoveSpeed; //adjustable; speed of player
    public Rigidbody2D Rigidbody; //create rigidbody variable
    public float moveSpeed = 5f;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private Vector3 moveDirection;
    bool isRunning = false;

    private Vector2 lastMoveDir = Vector2.down;

    private void OnEnable() //links to Game Over screen
    {
        PlayerHealth.OnPlayerDeath += DisablePlayerMovement;
    }

    private void OnDisable() //links to Game Over screen
    {
        PlayerHealth.OnPlayerDeath -= DisablePlayerMovement;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnablePlayerMovement();
        Rigidbody = GetComponent<Rigidbody2D>(); //enable rigidbody component

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //a summarized line that means player movement on the x and y axes is controlled by the WASD keys
        direction.Normalize(); //converts the vector to have a length of 1 while keeping its direction

        Rigidbody.linearVelocity = direction * moveSpeed; //gives a velocity vector

    }
    private void DisablePlayerMovement() //stop player movement when the player dies
    {
        Rigidbody.bodyType = RigidbodyType2D.Static;
    }

    private void EnablePlayerMovement() //enable player movement when the game restarts
    {
        Rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }

    void Move()
    {
        Vector3 moveDirection = Vector3.zero;
        //isRunning = false;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection.y += 1;
           // Debug.Log("Running Left");
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection.y -= 1;
           // Debug.Log("Running Left");
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection.x -= 1;
            isRunning = true;
            transform.localScale = new Vector3(-1, transform.localScale.y);
           // Debug.Log("Running Left");
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection.x += 1;
            isRunning = true;
           // transform.localScale = new Vector3(1, transform.localScale.y);
            //Debug.Log("Running Left");
        }

        isRunning = moveDirection != Vector3.zero;

        if (isRunning)
        {
            lastMoveDir = moveDirection;
        }

        transform.position += moveDirection.normalized * moveSpeed * Time.deltaTime;
        animator.SetBool("Run", isRunning);

        if (isRunning)
        {
            animator.SetFloat("MoveX", moveDirection.x);
            animator.SetFloat("MoveY", moveDirection.y);
        }
        else
        {
            animator.SetFloat("MoveX", lastMoveDir.x);
            animator.SetFloat("MoveY", lastMoveDir.y);
        }
    }
}
