using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 5f;
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
        if (player == null) return;

        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, player.position);

        float dot = Vector3.Dot(transform.up, directionToPlayer);

        bool playerInFront = dot > fieldOfViewThreshold;

        if (distance <= detectionRange && playerInFront)
        {
            if (!isChasing)
            {
                isChasing = true;
                if (audioSource != null) audioSource.Play();
            }

            ChasePlayer();
        }
        else
        {
            isChasing = false;
            ReturnToStart();
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