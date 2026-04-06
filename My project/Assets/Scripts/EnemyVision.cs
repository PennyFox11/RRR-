using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [Header("References")]
    public Enemy2Controller enemy2Controller; // Drag your Enemy2 GameObject here

    [Header("Detection Settings")]
    public float visionDistance = 5f;       // How far the enemy can "see"
    public LayerMask playerLayer;           // Assign Player layer
    public LayerMask obstacleLayer;         // Optional: block vision with walls

    void Update()
    {
        CheckPlayerInSight();
    }

    void CheckPlayerInSight()
    {
        if (enemy2Controller == null) return;

        // Only act if Enemy2 has detected the player
        if (enemy2Controller.IsPlayerDetected) // property, no parentheses
        {
            // Example: raycast to player for line-of-sight (optional)
             Vector2 direction = GetPlayerPosition() - (Vector2)enemy2Controller.transform.position;
            
            RaycastHit2D hit = Physics2D.Raycast(
                enemy2Controller.transform.position,
                direction,
                visionDistance,
                playerLayer | obstacleLayer
            );

            if (hit.collider != null && ((1 << hit.collider.gameObject.layer) & playerLayer) != 0)
            {
                // Player is in sight
                Debug.Log("Player is in front of Enemy2!");
            }
            else
            {
                // Player is no longer visible; inform Enemy2
                enemy2Controller.PlayerLost(); // Calls the public method
            }
        }
    }

    // Optional helper to find the player in the scene
    Vector2 GetPlayerPosition()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) return player.transform.position;
        return Vector2.zero;
    }
}