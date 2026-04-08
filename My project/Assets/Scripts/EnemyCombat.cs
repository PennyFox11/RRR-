using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public float damage = 10f;
    public float attackRange = 1.2f;
    public float attackCooldown = 2f; // seconds
    private float lastAttackTime;

    private Transform player; // will be assigned dynamically

    void Start()
    {
        Debug.Log("EnemyCombat running");
        // Dynamically find the Player at runtime
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("EnemyCombat: Player not found! Make sure the PlayerBase is tagged 'Player'.");
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        // Check if player is below the enemy on the Y-axis
        bool playerBelow = player.position.y < transform.position.y;

        if (distance <= attackRange && playerBelow)
        {
            // Check attack cooldown
            if (Time.time > lastAttackTime + attackCooldown)
            {
                PlayerHealth ph = player.GetComponent<PlayerHealth>();
                if (ph != null)
                {
                    ph.TakeDamage(damage);
                    Debug.Log("Player is being attacked");
                }
                lastAttackTime = Time.time;
            }
        }
    }
}
