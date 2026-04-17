using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Title: Set up a basic health system
//Author: Unity Learn
//Date: 2026
// Code vesrion: 6000.3.8f1
//Availability: https://learn.unity.com/course/2D-adventure-robot-repair/unit/health-system/tutorial/set-up-a-basic-health-system?version=6.3#6932d32bd5bfab44ab132cdd

//Title: Add damage zones to decrease health (static hazards)
//Author: Unity Learn
//Date: 2026
//Code version: 6000.3.8f1
//Availability: https://learn.unity.com/course/2D-adventure-robot-repair/unit/health-system/tutorial/add-damage-zones-to-decrease-health-static-hazards?version=6.3

//Title: How to make a HEALTH BAR in Unity!
//Author: Brackeys
//Date: 9 February 2026
//Code version: 2019.3.0f6
//Availability: https://www.youtube.com/watch?v=BLfNP4Sc_iA 

//Title: GAME OVER Menu In Unity Tutorial 
//Author: BMo
//Date: 17 March 2022
//Code version: 2020.3.22f1
//Availability: https://www.youtube.com/watch?v=ZfRbuOCAeE8 
public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    [SerializeField] public int maxHealth = 70; 
   [SerializeField] public int currentHealth; 

   public HealthBar healthBar;

   public float timeInvincible = 2.0f;
   bool isInvincible;
   float damageCooldown;

   public static void TriggerGameOver()
    {
        OnPlayerDeath?.Invoke();
    }

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

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("You're dead!");
            OnPlayerDeath?.Invoke();
        }
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
