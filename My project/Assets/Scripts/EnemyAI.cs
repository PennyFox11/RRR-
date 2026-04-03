using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 5f;
    public float attackRange = 1.2f;
    public float speed = 2f;

    private bool isChasing = false;

    // Update is called once per frame
    void Update()
    {
        Vector2 directionToPlayer = (player.position - transform.position).normalized;
        float distance = Vector2.Distance(transform.position, player.position);

        //Check if player is in front
        float dot = Vector2.Dot(transform.up, directionToPlayer);

        if (dot > 0.7f && distance <= detectionRange)
        {
            isChasing = true;
        }

        if (isChasing)
        {
            ChasePlayer(distance);
        }
    }

    void Attack()
    {
        Debug.Log("Enemy attacks!");
        //Add damage to player here - I'll have to figure this out later
    }
}
