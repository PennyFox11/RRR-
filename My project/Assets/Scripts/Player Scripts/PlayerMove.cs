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
    public float MoveSpeed; //adjustable; speed of player
    public Rigidbody2D Rigidbody; //create rigidbody variable

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
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //a summarized line that means player movement on the x and y axes is controlled by the WASD keys
        direction.Normalize(); //converts the vector to have a length of 1 while keeping its direction

        Rigidbody.linearVelocity = direction * MoveSpeed; //gives a velocity vector

    }
    private void DisablePlayerMovement() //stop player movement when the player dies
    {
        Rigidbody.bodyType = RigidbodyType2D.Static;
    }

    private void EnablePlayerMovement() //enable player movement when the game restarts
    {
        Rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }
}
