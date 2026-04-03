using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public HealthBar healthBar;

    public void SetMaxHealth(int health)
    {
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    publiv void SetHealth(int health)
    {
        healthBar.value = health;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
