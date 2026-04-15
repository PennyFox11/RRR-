// https://www.youtube.com/watch?v=ChE7u5EdR-U
// https://docs.unity3d.com/cn/current/ScriptReference/Physics2D.OverlapBoxAll.html?utm_source=chatgpt.com
// https://learn.unity.com/ 
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    AudioSource source;
    
    private GameObject attackArea = default;

    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;

    [SerializeField] private Transform attackPoint;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private int damage = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        if(attacking)
        {
            timer += Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }

    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(true);

        BoxCollider2D box = attackArea.GetComponent<BoxCollider2D>();

        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(
            attackPoint.position,
            box.size,
            0f,
            enemyLayers
        );

        foreach (Collider2D enemy in hitEnemies)
        {
            GuardHealth guardHealth = enemy.GetComponent<GuardHealth>();

            if (guardHealth != null)
            {
                guardHealth.ChangeHealth(-damage);

                if(!source.isPlaying)
                {
                    source.Play();
                }
            }
        }
    }
}
