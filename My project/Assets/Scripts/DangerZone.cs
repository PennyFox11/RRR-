using UnityEngine;

public class DangerZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth health = other.GetComponent<PlayerHealth>();

        if (health != null)
        {
            health.ChangeHealth(-1);
        }
    }
}
