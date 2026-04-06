using UnityEngine;
using TMPro; // Required for TextMeshPro

public class Enemy2Controller : MonoBehaviour
{
    [Header("Patrol Settings")]
    public Transform[] patrolPoints;      // L-shaped path: Left, Up, Down, Right
    public float patrolSpeed = 2f;        // Patrol speed

    [Header("Detection Settings")]
    public float detectionDistance = 1f;  // Distance in front to detect player
    public LayerMask playerLayer;         // Assign Player layer

    [Header("Countdown UI")]
    public TMP_Text countdownText;        // Drag CountdownText object
    public float countdownDuration = 10f; // 10-second countdown

    [Header("Audio")]
    public AudioSource alertAudio;        // Optional alert sound

    // Internal state
    private int currentPoint = 0;
    private bool playerDetected = false;
    private float countdownTimer = 0f;

    private LineRenderer lineRenderer;

    // --- PUBLIC INTERFACES FOR OTHER SCRIPTS ---
    public bool IsPlayerDetected => playerDetected;  // Read-only property

    public void PlayerLost()
    {
        playerDetected = false;
        countdownTimer = 0f;

        if (alertAudio != null) alertAudio.Stop();
        if (countdownText != null) countdownText.text = "";
    }

    // --- UNITY METHODS ---
    void Start()
    {
        // Initialize LineRenderer and draw patrol path
        lineRenderer = GetComponent<LineRenderer>();
        DrawPath();

        // Ensure countdown UI starts empty
        if (countdownText != null)
            countdownText.text = "";
    }

    void Update()
    {
        Patrol();
        DetectPlayer();
        UpdateCountdown();
    }

    // --- PATROL LOGIC ---
    void Patrol()
    {
        if (playerDetected) return; // Stop patrol when player detected
        if (patrolPoints.Length == 0) return;

        Transform target = patrolPoints[currentPoint];
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * patrolSpeed * Time.deltaTime;

        // Move to next point if close enough
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
        }
    }

    // --- PLAYER DETECTION ---
    void DetectPlayer()
    {
        Vector2 origin = (Vector2)transform.position + Vector2.right * detectionDistance;
        Vector2 size = new Vector2(1f, 1f);

        Collider2D hit = Physics2D.OverlapBox(origin, size, 0f, playerLayer);

        if (hit != null)
        {
            if (!playerDetected)
            {
                playerDetected = true;
                countdownTimer = countdownDuration;

                if (alertAudio != null) alertAudio.Play();
            }
        }
        else
        {
            if (playerDetected)
            {
                PlayerLost(); // Uses public method for consistency
            }
        }
    }

    // --- COUNTDOWN LOGIC ---
    void UpdateCountdown()
    {
        if (!playerDetected) return;

        countdownTimer -= Time.deltaTime;

        if (countdownText != null)
            countdownText.text = Mathf.Ceil(countdownTimer).ToString();

        if (countdownTimer <= 0f)
        {
            // Example: reload current scene (replace with your own Game Over logic)
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
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

    // Optional: visualize detection box in Scene view
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector2 origin = (Vector2)transform.position + Vector2.right * detectionDistance;
        Vector2 size = new Vector2(1f, 1f);
        Gizmos.DrawWireCube(origin, size);
    }
}