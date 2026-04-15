using UnityEngine;

public class DogDetection : MonoBehaviour
{
    private Enemy2Patrol patrolScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        patrolScript = GetComponentInParent<Enemy2Patrol>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            patrolScript.isPaused = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            patrolScript.isPaused = false;
        }
    }
}
