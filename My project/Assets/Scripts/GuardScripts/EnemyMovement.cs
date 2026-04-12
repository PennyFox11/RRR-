//Title: Creating Simple Enemy AI to Chase the Player (Unity Tutorial | 2D Top Down Shooter)
//Author: Ketra Games
// Date: 12 December 2022
// Availability: https://www.youtube.com/watch?v=XHrWtLZtzy8
// How I programmed enemy return function: https://discussions.unity.com/t/solved-make-enemy-move-back-to-start-position/633065 
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Vector3 startPosition;
    
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    [SerializeField]
    private float _returnSpeed;

    private Rigidbody2D _rigidbody;
    private PlayerAwarenessController _playerAwarenessController;
    private Vector2 _targetDirection;

    void Start()
    {
        startPosition = transform.position;
    }
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        if (_playerAwarenessController.AwareOfPlayer)
        {
            _targetDirection = _playerAwarenessController.DirectionToPlayer;
        }
        else
        {
            Vector2 directionToStart = (startPosition - transform.position);

            if (directionToStart.magnitude > 0.1f) // prevent jitter
            {
               _targetDirection = directionToStart.normalized; // https://docs.unity3d.com/ScriptReference/Vector3-normalized.html
            }
            else
            {
                _targetDirection = Vector2.zero;
            }
        }
    }

    private void RotateTowardsTarget()
    {
        if (_targetDirection == Vector2.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

        _rigidbody.SetRotation(rotation);
    }

    private void SetVelocity()
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
