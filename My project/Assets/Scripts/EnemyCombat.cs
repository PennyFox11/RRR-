using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public float damage = 10f;
    public float attackRange = 1.2f;
    public Transform player;

    public float attackCooldown = 2f; // seconds
    private float lastAttackTime;

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        bool playerBelow = player.position.y < transform.position.y;

        if (distance <= attackRange && playerBelow)
        {
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