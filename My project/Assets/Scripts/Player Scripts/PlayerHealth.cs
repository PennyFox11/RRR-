using System; //allow for Action function in line 31
using UnityEngine;
using UnityEngine.UI; //enable use of health bar UI
using UnityEngine.SceneManagement; //enable use of game over screen

//Title: Set up a basic health system
//Author: Unity Learn
//Date: 2026
// Code version: Unity 6000.3.8f1
//Availability: https://learn.unity.com/course/2D-adventure-robot-repair/unit/health-system/tutorial/set-up-a-basic-health-system?version=6.3#6932d32bd5bfab44ab132cdd

//Title: Add damage zones to decrease health (static hazards)
//Author: Unity Learn
//Date: 2026
//Code version: Unity 6000.3.8f1
//Availability: https://learn.unity.com/course/2D-adventure-robot-repair/unit/health-system/tutorial/add-damage-zones-to-decrease-health-static-hazards?version=6.3

//Title: How to make a HEALTH BAR in Unity!
//Author: Brackeys
//Date: 9 February 2026
//Code version: Unity 2019.3.0f6
//Availability: https://www.youtube.com/watch?v=BLfNP4Sc_iA 

//Title: GAME OVER Menu In Unity Tutorial 
//Author: BMo
//Date: 17 March 2022
//Code version: Unity 2020.3.22f1
//Availability: https://www.youtube.com/watch?v=ZfRbuOCAeE8 
public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDeath; //declare game over event
    [SerializeField] public int maxHealth = 70; //adjust in inspector and access from other scripts; the player's maximum health
   [SerializeField] public int currentHealth; //adjust in inspector and access from other scripts

   public HealthBar healthBar; //declare the health bar; make it public

   public float timeInvincible = 2.0f; //how long the player remains invincible after taking damage
   bool isInvincible; //whether the player is currently invincible
   float damageCooldown; //how much time is remaining until the player is no longer invincible and takes damage

   public static void TriggerGameOver() 
    {
        OnPlayerDeath?.Invoke();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth; //player starts with full health
        healthBar.SetMaxHealth(maxHealth); //health bar starts full
    }

    public void ChangeHealth (int amount)
    {
        if (amount < 0) //the "amount" parameter has a value below zero. The value will be below zero if a health decrease has been made through the ChangeHealth function
        {
            if (isInvincible) //exit the ChangeHealth function if the player is already invincible. 
            {
                return;
            }
            isInvincible = true; //avoid further damage during cooldown
            damageCooldown = timeInvincible; //sets the cooldown timer to the current value for the public timeInvincible variable
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth); //current health can never exceed max health
        Debug.Log(currentHealth + "/" + maxHealth); //print result when health changes (placeholder)
        
        healthBar.SetHealth(currentHealth); //adjust health bar to show current health

        if (currentHealth <= 0) //if player health reaches zero
        {
            currentHealth = 0;
            Debug.Log("You're dead!");
            OnPlayerDeath?.Invoke(); //if OnPlayer Death is not null, invoke the player death function
        }
    }

    void Update()
    {
        if (isInvincible) //the player has taken damage since the last frame
        {
            damageCooldown -= Time.deltaTime; //reduces the damageCooldown timer value every frame
            if (damageCooldown < 0) //if the timer countdown has finished
            {
                isInvincible = false; //the player is vulnerable to damage
            }
        }
    }
}
