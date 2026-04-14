//https://learn.unity.com/course/2D-adventure-robot-repair/unit/health-system/tutorial/set-up-a-basic-health-system?version=6.3#6932d32bd5bfab44ab132cdd 
using UnityEngine;

public class GuardHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth = 50;
    [SerializeField] int currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void ChangeHealth (int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
