//Title: Create a health collectible using triggers
//Author: Unity Learn
//Date: 2026
//Availability: https://learn.unity.com/course/2D-adventure-robot-repair/unit/health-system/tutorial/create-a-health-collectible-using-triggers?version=6.3
using UnityEngine;

public class Healing : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth health = other.GetComponent<PlayerHealth>();

        if (health != null)
        {
            health.ChangeHealth(60);
            Debug.Log("Player health has increased by 60");
        }
    }
}

