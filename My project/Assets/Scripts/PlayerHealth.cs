using UnityEngine;
using UnityEngine.SceneManagement; // Needed for restart

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log("Player took damage: " + amount);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player has died");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}