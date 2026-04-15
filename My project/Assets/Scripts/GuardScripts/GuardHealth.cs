//https://learn.unity.com/course/2D-adventure-robot-repair/unit/health-system/tutorial/set-up-a-basic-health-system?version=6.3#6932d32bd5bfab44ab132cdd 
////https://www.youtube.com/watch?v=BLfNP4Sc_iA
using UnityEngine;

public class GuardHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth = 50;
    [SerializeField] int currentHealth;

    public HealthBar2 healthBar2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthBar2.SetMaxHealth(maxHealth);
    }

    public void ChangeHealth (int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);

        healthBar2.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Update is called once per frame
    void Die()
    {
        Destroy(gameObject);
    }
}
