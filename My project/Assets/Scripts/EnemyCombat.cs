using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public float damage = 10f;
    public float attackRange = 1.2f;
    public Transform player;

    public float attackCooldown = 1f; // seconds
    private float lastAttackTime;

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            Vector3 dir = (player.position - transform.position).normalized;
            float dot = Vector3.Dot(transform.up, dir);

            if (dot > 0.5f && Time.time > lastAttackTime + attackCooldown)
            {
                PlayerHealth ph = player.GetComponent<PlayerHealth>();
                if (ph != null)
                {
                    ph.TakeDamage(damage);
                }

                lastAttackTime = Time.time;
            }
        }
    }
}