//Title: Creating Simple Enemy AI to Chase the Player (Unity Tutorial | 2D Top Down Shooter)
//Author: Ketra Games
// Date: 12 December 2022
//Code version: Unity 2021.3.11f1
// Availability: https://www.youtube.com/watch?v=XHrWtLZtzy8

using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; } //indicates whether enemy is aware of player

    public Vector2 DirectionToPlayer { get; private set; } //enemy knows direction of player

    [SerializeField]
    private float _playerAwarenessDistance; //adjust in inspector; the distance at which the enemy starts to move towards player

    private Transform _player; //to know position of player

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMove>().transform; //find the player (the game object with the PlayerMove component)
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position; //tells us position of player
        DirectionToPlayer = enemyToPlayerVector.normalized; //direction to player (with magnitude of 1)

        if (enemyToPlayerVector.magnitude <= _playerAwarenessDistance) //check if player is close enough
        {
            AwareOfPlayer = true;
        }
        else
        {
            AwareOfPlayer = false;
        }
        
    }
}
