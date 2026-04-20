//Title: Set up a basic health system
//Author: Unity Learn
//Date: 2026
//Code version: Unity 6000.3.8f1
//Availability: https://learn.unity.com/course/2D-adventure-robot-repair/unit/health-system/tutorial/set-up-a-basic-health-system?version=6.3#6932d32bd5bfab44ab132cdd 

//Title: How to make a HEALTH BAR in Unity!
//Author: Brackeys
//Date: 9 February 2020
//Code version: Unity 2019.3.0f6
//Availability: https://www.youtube.com/watch?v=BLfNP4Sc_iA
using UnityEngine;

public class GuardHealth : MonoBehaviour
{
    public GameObject door;
    
    private bool doorDestroyed;
    
    [SerializeField] public int maxHealth = 50; //adjust this in the inspector; public and can be accessed from other scripts
    [SerializeField] int currentHealth; // adjust in inspector

    public HealthBar2 healthBar2; // public variable; UI of guard health 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() //runs once at the beginning; enemy starts with full health (shown in health bar)
    {
        currentHealth = maxHealth;
        healthBar2.SetMaxHealth(maxHealth);
    }

    public void ChangeHealth (int amount) //determines how the enemy takes damage and how it is displayed
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth); //current health can never be higher than max health
        Debug.Log(currentHealth + "/" + maxHealth); //show change on console

        healthBar2.SetHealth(currentHealth); //show change in UI

        if (currentHealth <= 0)
        {
            Die();
            Destroy(door);
        }
    }

    // Update is called once per frame
    void Die() //enemy vanishes when health is zero
    {
        Destroy(gameObject);
    }
}
