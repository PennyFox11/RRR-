using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 10f;
    public float moveSpeed = 2f;

    [Range(-1f, 1f)]
    public float fieldOfViewThreshold = 0.5f;

    private Vector3 startPosition;
    private bool isChasing = false;

    private AudioSource audioSource;

    void Start()
    {
        startPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
{
    if (player == null)
    {
        return;
    }

    Vector3 directionToPlayer = player.position - transform.position;
    float distance = directionToPlayer.magnitude;

    bool playerInFront = player.position.y < transform.position.y;

    if (distance <= detectionRange && playerInFront)
    {
        if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            moveSpeed * Time.deltaTime
        );
    }
    else
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            startPosition,
            moveSpeed * Time.deltaTime
        );
    }

    }

    void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            moveSpeed * Time.deltaTime
        );
    }

    void ReturnToStart()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            startPosition,
            moveSpeed * Time.deltaTime
        );
    }
}