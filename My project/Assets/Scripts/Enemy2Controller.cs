using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Enemy2Controller : MonoBehaviour
{
    [Header("Patrol Settings")]
    public Transform[] patrolPoints;
    public float patrolSpeed = 2f;

    [Header("Detection Settings")]
    public float detectionRadius = 3f;
    [Range(-1f, 1f)]
    public float visionThreshold = 0.5f; // controls how wide vision is

    [Header("Countdown UI")]
    public TMP_Text countdownText;
    public float countdownDuration = 10f;

    [Header("Audio")]
    public AudioSource alertAudio;

    private int currentPoint = 0;
    private bool playerDetected = false;
    private float countdownTimer = 0f;

    private LineRenderer lineRenderer;
    private Transform player;

    private Vector2 moveDirection; // NEW: tracks movement direction

    public bool IsPlayerDetected => playerDetected;

    // --- PLAYER LOST ---
    public void PlayerLost()
    {
        playerDetected = false;
        countdownTimer = 0f;

        if (alertAudio != null) alertAudio.Stop();
        if (countdownText != null) countdownText.text = "";
    }

    // --- START ---
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        DrawPath();

        if (countdownText != null)
            countdownText.text = "";

        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("Enemy2Controller: Player not found!");
        }
    }

    // --- UPDATE ---
    void Update()
    {
        Patrol();
        DetectPlayer();
        UpdateCountdown();
    }

    // --- PATROL ---
    void Patrol()
    {
        if (playerDetected) return;
        if (patrolPoints.Length == 0) return;

        Transform target = patrolPoints[currentPoint];

        // 🔥 Track movement direction
        moveDirection = (target.position - transform.position).normalized;

        transform.position += (Vector3)moveDirection * patrolSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
        }
    }

    // --- DETECTION (DIRECTIONAL + LINE OF SIGHT) ---
    void DetectPlayer()
    {
        if (player == null) return;

        Vector2 toPlayer = (player.position - transform.position).normalized;
        float distance = Vector2.Distance(transform.position, player.position);

        // 🔥 Check if player is in front of movement
        float dot = Vector2.Dot(moveDirection, toPlayer);

        if (distance <= detectionRadius && dot > visionThreshold)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, detectionRadius);

            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                if (!playerDetected)
                {
                    playerDetected = true;
                    countdownTimer = countdownDuration;

                    if (alertAudio != null)
                        alertAudio.Play();
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

    // --- COUNTDOWN ---
    void UpdateCountdown()
    {
        if (!playerDetected) return;

        countdownTimer -= Time.deltaTime;

        if (countdownText != null)
            countdownText.text = Mathf.Ceil(countdownTimer).ToString();

        if (countdownTimer <= 0f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // --- DRAW PATROL PATH ---
    void DrawPath()
    {
        if (patrolPoints == null || patrolPoints.Length == 0 || lineRenderer == null)
            return;

        lineRenderer.positionCount = patrolPoints.Length;

        for (int i = 0; i < patrolPoints.Length; i++)
        {
            lineRenderer.SetPosition(i, patrolPoints[i].position);
        }
    }

    // --- GIZMOS (DEBUG) ---
    private void OnDrawGizmosSelected()
    {
        // Detection radius
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        // Direction line
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)moveDirection * detectionRadius);
    }
}