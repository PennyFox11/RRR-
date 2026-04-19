//Title: Creating Simple Enemy AI to Chase the Player (Unity Tutorial | 2D Top Down Shooter)
//Author: Ketra Games
// Date: 12 December 2022
//Code version: Unity 2021.3.11f1
// Availability: https://www.youtube.com/watch?v=XHrWtLZtzy8

// Title: [Solved] Make enemy move back to start position
//Author: Unity Discussions
//Date: 13 July 2016
// https://discussions.unity.com/t/solved-make-enemy-move-back-to-start-position/633065 

//Title: Vector3.normalized
//Author: Unity Documentation
//Date: 17 April 2026
//Code version: Unity 6000.4
//Availability: https://docs.unity3d.com/ScriptReference/Vector3-normalized.html
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Vector3 startPosition; //setting a position as a "Vector"
    
    [SerializeField]
    private float _speed; //make the variable of speed, "SerializeField" to adjust it in inspector even when it's private

    [SerializeField]
    private float _rotationSpeed; // make the variable of rotation speed (how fast the enemy turns), made adjustable in inspector even though it's private

    [SerializeField]
    private float _returnSpeed; //make variable of return speed (how fast enemy returns to its start position), can adjust in inspector

    private Rigidbody2D _rigidbody; // references the objects rigidbody component to apply forces to game object and control it
    private PlayerAwarenessController _playerAwarenessController; //calls another script that detects player
    private Vector2 _targetDirection; //establish a 2D position as target

    void Start() //when game starts, instantiate object in scene so it can move on change
    {
        startPosition = transform.position; 
    }
    private void Awake() //Functions like "Void Start", initializes variables (in this case, rigidbody and PlayerAwarenessController script)
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
    }

    private void FixedUpdate() //update at regular, fixed intervals
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection() //if the player is a certain distance from the enemy, the enemy will move in the player's direction
    {
        if (_playerAwarenessController.AwareOfPlayer)
        {
            _targetDirection = _playerAwarenessController.DirectionToPlayer;
        }
        else
        {
            Vector2 directionToStart = (startPosition - transform.position);

            if (directionToStart.magnitude > 0.1f) 
            {
               _targetDirection = directionToStart.normalized; 
            }
            else
            {
                _targetDirection = Vector2.zero;
            }
        }
    }

    private void RotateTowardsTarget() // the enemy sprite will rotate towards the player as it pursues the player
    {
        if (_targetDirection == Vector2.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        _rigidbody.SetRotation(rotation);
    }

    private void SetVelocity() // the velicoty at which the enemy chases the player
    {
        if (_targetDirection == Vector2.zero)
        {
            _rigidbody.linearVelocity = Vector2.zero;
        }
        else
        {
            float currentSpeed = _playerAwarenessController.AwareOfPlayer ? _speed : _returnSpeed;
            _rigidbody.linearVelocity = transform.up * _speed;
        }
    }
}
