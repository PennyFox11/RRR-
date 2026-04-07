using UnityEngine;
using TMPro; // Required for TextMeshPro
using UnityEngine.SceneManagement;

public class Enemy2Controller : MonoBehaviour
{
    [Header("Patrol Settings")]
    public Transform[] patrolPoints;      
    public float patrolSpeed = 2f;

    [Header("Detection Settings")]
    public float detectionDistance = 1f;  
    public LayerMask playerLayer;         

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

    // Dynamic reference to the Player
    private Transform player;

    public bool IsPlayerDetected => playerDetected;  

    public void PlayerLost()
    {
        playerDetected = false;
        countdownTimer = 0f;

        if (alertAudio != null) alertAudio.Stop();
        if (countdownText != null) countdownText.text = "";
    }

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        DrawPath();

        if (countdownText != null)
            countdownText.text = "";

        // --- DYNAMIC PLAYER LOOKUP ---
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("Enemy2Controller: Player not found! Make sure the PlayerBase is tagged 'Player'.");
        }
    }

    void Update()
    {
        Patrol();
        DetectPlayer();
        UpdateCountdown();
    }

    void Patrol()
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
                PlayerLost();
            }
        }
    }

    void UpdateCountdown()
    {
        if (!playerDetected) return;

        countdownTimer -= Time.deltaTime;

        if (countdownText != null)
            countdownText.text = Mathf.Ceil(countdownTimer).ToString();

        if (countdownTimer <= 0f)
        {
            // Example: reload current scene (replace with your own Game Over logic)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector2 origin = (Vector2)transform.position + Vector2.right * detectionDistance;
        Vector2 size = new Vector2(1f, 1f);
        Gizmos.DrawWireCube(origin, size);
    }
}