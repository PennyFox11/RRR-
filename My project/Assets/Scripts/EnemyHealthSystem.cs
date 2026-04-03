using UnityEngine;

public class Enemyhealthsystem : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth;

    public HealthBar healthBar; // the existing slider

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage, Vector2 attackerPosition)
    {
        Vector2 directionToAttacker = (attackerPosition - (Vector2)transform.position).normalized;

        float dot = Vector2.Dot(transform.up, directionToAttacker);

        if (dot > 0.5f)
        {
            Debug.Log("Hit from FRONT");
        }
        else if (dot < -0.5f)
        {
            Debig.Log("Hit from BEHIND");
            damage *=2; //bonus damage from behind - can be adjusted later
        }
        else
        {
            float side = Vector2.Dot(transform.right, directionToAttacker);

            if (side > 0)
            {
                Debug.Log("Hit from RIGHT");
            }
            else
            {
                Debug.Log("Hit from LEFT");
            }
        }

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
