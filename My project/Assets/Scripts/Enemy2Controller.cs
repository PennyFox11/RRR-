using UnityEngine;
using TMPro; // links to text
using UnityEngine.SceneManagement;

public class Enemy2Controller : MonoBehaviour
{
    [Header("Patrol Settings")]
    public Transform[] patrolPoints; 
    public float patrolSpeed = 2f;

    [Header("Detection Settings")]
    public float detectionRadius = 3f;

    [Header("Countdown UI")]
    public TMP_Text countdownText; 
    public float countdownDuration = 10f;

    [Header("Audio")]
    public AudioSource alertAudio; 

    // Internal state
    private int currentPoint = 0;
    private bool playerDetected = false;
    private float countdownTimer = 0f;

    private LineRenderer lineRenderer;
    private Transform player;

    public bool IsPlayerDetected => playerDetected;

    // --- PLAYER LOST ---
    public void PlayerLost() // in the scenario that the player is not detected by the dog
    {
        playerDetected = false;
        countdownTimer = 0f;

        if (alertAudio != null) alertAudio.Stop();
        if (countdownText != null) countdownText.text = "";
    }

    // --- START ---
    void Start() 
    {
        lineRenderer = GetComponent<LineRenderer>(); // draw the dog's path
        DrawPath();

        if (countdownText != null)
            countdownText.text = "";

        // finds the player (currently in a different scene)
        GameObject playerObj = GameObject.FindWithTag("Player"); 
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("Enemy2Controller: Player not found! Ensure Player is tagged 'Player'.");
        }
    }

    // --- UPDATE ---
    void Update() // lists the scenarios that must be checked each frame
    {
        Patrol();
        DetectPlayer();
        UpdateCountdown();
    }

    void Patrol() // runs the dog's patrol mechanic
    {
        if (playerDetected) return;
        if (patrolPoints.Length == 0) return;

        Transform target = patrolPoints[currentPoint];
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * patrolSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
        }
    }

    void DetectPlayer() // check if player is in front and nearby
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        float distance = Vector2.Distance(transform.position, player.position);

        bool playerAbove = player.position.y > transform.position.y; // defines what "above" means

        if (distance <= detectionRadius && playerAbove)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, detectionRadius);

            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                if (!playerDetected)
                {
                    playerDetected = true;
                    countdownTimer = countdownDuration; // starts countdown

                    if (alertAudio != null)
                        alertAudio.Play(); // dog barks
                }
            }
            else
            {
                if (playerDetected)
                    PlayerLost();
            }
        }
        else
        {
            if (playerDetected)
                PlayerLost();
        }
    }

    void UpdateCountdown() // manages the countdown
    {
        if (!playerDetected) return;

        countdownTimer -= Time.deltaTime; // subtract by one second

        if (countdownText != null)
            countdownText.text = Mathf.Ceil(countdownTimer).ToString();

        if (countdownTimer <= 0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void DrawPath() // draws the patrol path
    {
        if (patrolPoints == null || patrolPoints.Length == 0 || lineRenderer == null)
            return;

        lineRenderer.positionCount = patrolPoints.Length;

        for (int i = 0; i < patrolPoints.Length; i++)
        {
            lineRenderer.SetPosition(i, patrolPoints[i].position);
        }
    }

    private void OnDrawGizmosSelected() // debug visuals
    {
        // Detection radius
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        if (player != null) // line to the player
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, player.position);
        }
    }
}