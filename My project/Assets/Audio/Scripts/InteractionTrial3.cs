using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static PlayerMove;


public class InteractionTrial3 : MonoBehaviour
{
    public PlayerHealth playerHealth;
    [SerializeField] private GameObject player;
    public EnemyMovement enemyMovement;

    [SerializeField] private float speed = 15.0f;
    private object health;

    public int distance = 10;

    public void Start()
    { 
        PlayerHealth health = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            EnemyMovement();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            speed = 0f;
        }
    }

    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        Debug.Log("Targeting Player");
    }

    public void EnemyMovement()
    {
        
    }
}
