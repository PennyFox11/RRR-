using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//https://learn.unity.com/course/2D-adventure-robot-repair/unit/health-system/tutorial/set-up-a-basic-health-system?version=6.3#6932d32bd5bfab44ab132cdd
//https://learn.unity.com/course/2D-adventure-robot-repair/unit/health-system/tutorial/add-damage-zones-to-decrease-health-static-hazards?version=6.3
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth = 70; 
   [SerializeField] public int currentHealth; 

   public HealthBar healthBar;

   public float timeInvincible = 2.0f;
   bool isInvincible;
   float damageCooldown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void ChangeHealth (int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
            {
                return;
            }
            isInvincible = true;
            damageCooldown = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
        
        healthBar.SetHealth(currentHealth);
    }

    void Update()
    {
        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown < 0)
            {
                isInvincible = false;
            }
        }
    }
}
