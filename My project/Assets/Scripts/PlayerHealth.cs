using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//https://learn.unity.com/course/2D-adventure-robot-repair/unit/health-system/tutorial/set-up-a-basic-health-system?version=6.3#6932d32bd5bfab44ab132cdd

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth = 70; 
   [SerializeField] public int currentHealth; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        //UpdateHealthBar();
    }

    void FixedUpdate()
    {
        
    }

    public void ChangeHealth (int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
