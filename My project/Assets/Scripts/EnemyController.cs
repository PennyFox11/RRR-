using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform player;                 // will be found dynamically
    public float detectionRange = 10f;
    public float moveSpeed = 2f;

    [Range(-1f, 1f)]
    public float fieldOfViewThreshold = 0.5f;

    private Vector3 startPosition;
    private AudioSource audioSource;

    void Start()
    {
        startPosition = transform.position;
        audioSource = GetComponent<AudioSource>();

        // Dynamically find the player at runtime
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("EnemyController: Player not found! Make sure the PlayerBase is tagged 'Player'.");
        }
    }

    void Update()
    {
        if (player == null) return;

        Vector3 directionToPlayer = player.position - transform.position;
        float distance = directionToPlayer.magnitude;

        // Check if player is "in front" (below the enemy on the Y-axis)
        bool playerInFront = player.position.y < transform.position.y;

        if (distance <= detectionRange && playerInFront)
        {
            // Play audio only once
            if (!audioSource.isPlaying)
                audioSource.Play();

            // Move towards player
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                moveSpeed * Time.deltaTime
            );
        }
        else
        {
            // Move back to start position
            transform.position = Vector3.MoveTowards(
                transform.position,
                startPosition,
                moveSpeed * Time.deltaTime
            );
        }
    }
}
