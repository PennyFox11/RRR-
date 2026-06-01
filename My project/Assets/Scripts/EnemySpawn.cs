//This script was created with tutor help

//Title: Instantiating prefabs at runtime
//Author: Unity Documentation
//Date: 30 May 2026
//Code version: Unity 6000.4
//Availability: https://docs.unity3d.com/6000.4/Documentation/Manual/instantiating-prefabs.html

//Title: Instantiate at intervals
//Author: Unity Discussions
//Date: February 2014
//Code version: 
//Availability: https://discussions.unity.com/t/instantiate-at-intervals/95695 

//Title: Time.deltaTime
//Author: Unity Documentation
//Date: 30 May 2026
//Code version: Unity 6000.4
//Availability: https://docs.unity3d.com/6000.4/Documentation/ScriptReference/Time-deltaTime.html

//Title: MonoBehavior.Start()
//Author: Unity Documentation
//Date: 30 May 2026
//Code version: Unity 6000.4
//Availability: https://docs.unity3d.com/6000.4/Documentation/ScriptReference/MonoBehaviour.Start.html 
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header ("Spawn Settings")]
    public GameObject guardEnemyPrefab;
    public float spawnRadius = 5f;
    private GameObject currentEnemy;
    private bool hasSpawned = false;
    public float spawnInterval = 2.0f; //delay between spawining 
    public float initialDelay = 0f;
    private float timer = 0f;

    void Start()
    {
        timer = -initialDelay;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        if (hasSpawned)
        {
            return;
        }

        Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;

        Vector3 spawnPosition =
            transform.position +
            new Vector3(randomOffset.x, randomOffset.y, 0);

        //Vector3 spawnPosition = transform.position + new Vector3(randomOffset.x, randomOffset.y, 0);

        currentEnemy = Instantiate(
            guardEnemyPrefab,
            spawnPosition,
            Quaternion.identity
        );

        hasSpawned = true;

        Debug.Log("Enemy Spawned!");
    }

    void OnDrawGizmosSelected()//visual guide for the spawn point and where to place it in the scene
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
