using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public float attackRange = 1.5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryAttack();
        }
    }

    void TryAttack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach (Collider2D hit in hits)
        {
            EnemyHealth enemy = hit.GetComponent<EnemyHealth>();

            if (enemy != null)
            {
                AttackEnemy(enemy);
            }
        }
    }

    void AttackEnemy(EnemyHealth enemy)
    {
        Vector3 dirToEnemy = (enemy.transform.position - transform.position).normalized;
        float dot = Vector3.Dot(enemy.transform.up, dirToEnemy);

        // If NOT in front → allow damage
        if (dot < 0.5f)
        {
            enemy.TakeDamage(25f);
        }
    }
}