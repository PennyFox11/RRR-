//Title: Unity Tutorial (2021) - Making the Player Attack
//Author: Modding by Kaupenjoe
//Date: 4 August 2021
//Code version: Unity 2020.3.13f1
//Availability: https://www.youtube.com/watch?v=ChE7u5EdR-U

//Title: Physics2D.OverlapBoxAll
//Author: Unity Documentation
//Date: 15 December 2025
//Code version: Unity 6000.0.65f1
//Availability: https://docs.unity3d.com/cn/current/ScriptReference/Physics2D.OverlapBoxAll.html?utm_source=chatgpt.com

//Title: 2D Game Kit Reference Guide
//Author: Unity Learn
//Date: 2026
//Code version: Unity 6000.3.8f1
//Availability: https://learn.unity.com/ 
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    AudioSource source; //get the audio source component
    
    private GameObject attackArea = default; //area in which attack happens

    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;

    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private int damage = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject; // refers to the first child of teh game object
        source = GetComponent<AudioSource>(); //refers to/gets the audio source
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) //player attacks when spacebar is pressed
        {
            Attack();
        }

        if(attacking) 
        {
            timer += Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0; //reset the timer
                attacking = false;
                attackArea.SetActive(attacking); 
            }
        }
    }

    private void Attack() //the "attack" method
    {
        attacking = true;
        attackArea.SetActive(true);

        BoxCollider2D box = attackArea.GetComponent<BoxCollider2D>();

        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll( //get a list of all colliders that fall within a boz area
            attackPoint.position,
            box.size,
            0f,
            enemyLayers
        );

        foreach (Collider2D enemy in hitEnemies) 
        {
            GuardHealth guardHealth = enemy.GetComponent<GuardHealth>(); //find the enemy's health

            if (guardHealth != null) //if the health exists / is not zero
            {
                guardHealth.ChangeHealth(-damage); //reduce health

                if(!source.isPlaying)
                {
                    source.Play(); //play attack sound
                }
            }
        }
    }
}
