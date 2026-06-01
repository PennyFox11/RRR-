
using Pathfinding; //this is from a downloaded unity package 
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;



public class EnemyAI : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public bool isPaused = false;
    private Animator anim;
   

    public StateMachine StateMachine { get; private set; }
    public Transform player;
   

    [Header("Pathfinding")] //this will show in the script editor
    private Transform target;   //the target the enemy is targeting
    public float activateDistance = 5f; //this will be the activation distance
    public float pathUpdateSeconds = 0.5f; //this is how often we are going to update the A* algorithm that is used to detect colliders

    [Header("Physics")]
    public float speed = 2.5f;
    public float nextWaypointDistance = 3f; //this is how far away the enemy needs to be in order to start moving towards the next way point.


    [Header("Custom Behaviour")] //this is useful for making enemies dumb.
    public bool followEnabled = true; //so if this is false, nothing in the script will do anything.
    public bool directionLookEnabled = true; //thats to see if the enemy will change direction or not.
    public bool withinStoppingDistance = false;

    [Header("Combat")]
    public float attackDistance = 0.5f; // The distance at which the enemy will initiate an attack

    private AudioSource footstepAudio;

    //[Header("Enemy Type")]
    //public bool melee;
    //public bool shooting;

    //[Header("Melee")]
    //public GameObject swordStrikePrefab;
    //private GameObject swordStrikeInstance;
    //private float lastAttackTime = 0.0f; // Track the time of the last attack.
    //private bool canAttack = true; // Flag to track if the enemy can attack.
    //public float attackCooldown = 3.0f; // Cooldown time between attacks.


    //[Header("Shooting")]
    //public GameObject fireThrowPrefab;
    //private GameObject fireThrowInstance;

    private Path path; //path finding feature
    private int currentWayPoint = 0;
    Seeker seeker;
    Rigidbody2D rb;
    bool IsWalking = false;
    bool IsAttacking = false;
   

    private Vector2 currentVelocity;
   // protected override string AnimBoolName => "IsWalking";
   private void Awake()
    {
        StateMachine = new StateMachine();
        //anim = GetComponent<Animator>();
    }
    


    public void Start()
    {
        anim = GetComponent<Animator>();

       
        spriteRenderer = GetComponent<SpriteRenderer>();
        footstepAudio = GetComponent<AudioSource>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            target = playerObject.transform;
        }

        InvokeRepeating("UpdatePath", 0f, pathUpdateSeconds);
    }

    private void FixedUpdate()
    {
        if (TargetInDistance() && followEnabled)
        {
            anim.SetBool("IsWalking", IsWalking); //when seeker path has started, walk animation is activated at the same time
            IsWalking = true;
            PathFollow();
            
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }

        if (rb.linearVelocity.magnitude > 0.1f)
        {
            if (!footstepAudio.isPlaying)
            {
                footstepAudio.Play();
            }
        }
        else
        {
            footstepAudio.Pause();
        }

        float distance = Vector2.Distance(transform.position, target.transform.position);

    }

    private void UpdatePath()
    {
        if (followEnabled && TargetInDistance() && seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);

            //anim.SetBool("IsWalking", IsWalking); //when seeker path has started, walk animation is activated at the same time
           // IsWalking = true;
        }
    }



    private void PathFollow()
    {
        if (path == null)
        {
            return;
           
        }

        // Reached the end of the path
        if (currentWayPoint >= path.vectorPath.Count)
        {
            return;
        }

        // Calculate direction
        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        Vector2 force = direction * speed;

        // Movement using Vector2.SmoothDamp
        if (!withinStoppingDistance) // apply SmoothDamp only when the enemy is not within the stopping distance
        {
            rb.linearVelocity = Vector2.SmoothDamp(rb.linearVelocity, force, ref currentVelocity, 0.5f);
        }

        // Next WayPoint
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);
        if (distance < nextWaypointDistance)
        {
            currentWayPoint++;
        }



        // Attack behavior
        float targetDistance = Vector2.Distance(rb.position, target.transform.position);
        if (followEnabled && targetDistance < activateDistance)
        {
            
           
            if (targetDistance <= attackDistance)
            {
                // Stop the enemy movement
                rb.linearVelocity = Vector2.zero;
                withinStoppingDistance = true;

                //if (melee && canAttack)
                //{
                //    //Instantiate the sword strike animation.
                //    swordStrikeInstance = Instantiate(swordStrikePrefab, transform.position, Quaternion.identity);
                //    canAttack = false;
                //    Destroy(swordStrikeInstance, 0.35f);
                //}
                //if (shooting && canAttack)
                //{
                //    // Instantiate the bullet animation.
                //    fireThrowInstance = Instantiate(fireThrowPrefab, transform.position, Quaternion.identity);
                //    canAttack = false;
                //}
                //dealing damage to the target

            }
            else
            {
                withinStoppingDistance = false;
            }
        }
        //if (!canAttack && Time.time - lastAttackTime >= attackCooldown)
        //{
        //    canAttack = true;
        //    lastAttackTime = Time.time;
        //}
    }

    private bool TargetInDistance()
    {
       

        if (target == null)
        {
           
            return false;

        }
       
        return Vector2.Distance(transform.position, target.position) < activateDistance; //checking if the enemy is within the activation distance 

    }

    private void OnPathComplete(Path p)
    {
        anim.SetBool("IsAttacking", IsAttacking);
        IsAttacking = true;

        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

   

   
}
