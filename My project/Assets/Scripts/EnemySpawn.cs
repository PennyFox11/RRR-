//This script was partially created with tutor help
//https://docs.unity3d.com/6000.4/Documentation/Manual/instantiating-prefabs.html
//
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header ("Spawn Settings")]
    public GameObject guardEnemyPrefab;
    public float spawnRadius = 5f;
    private GameObject currentEnemy;
    private bool hasSpawned = false;

    void Start()
    {
        SpawnEnemy();
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
