using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    private Enemy2Controller enemy;

    private void Start()
    {
        enemy = GetComponentInParent<Enemy2Controller>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.PlayerDetected();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.PlayerLost();
        }
    }
}