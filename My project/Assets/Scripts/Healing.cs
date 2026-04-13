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

