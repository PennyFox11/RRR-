//This script was created with tutor help
//https://docs.unity3d.com/6000.4/Documentation/Manual/instantiating-prefabs.html
//https://discussions.unity.com/t/instantiate-at-intervals/95695 
//https://docs.unity3d.com/6000.4/Documentation/ScriptReference/Time-deltaTime.html
//https://docs.unity3d.com/6000.4/Documentation/ScriptReference/MonoBehaviour.Start.html 
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header ("Spawn Settings")]
    public GameObject guardEnemyPrefab;
    public float spawnRadius = 5f;
    private GameObject currentEnemy;
    private bool hasSpawned = false;
    public float spawnInterval = 2.0f;
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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
