//This script was created with tutor help
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header ("Spawn Settings")]
    public GameObject guardEnemyPrefab;
    public float spawnRate = 2f; 
    public float spawnRadius = 5f;

    [Header ("Limit Settings")]
    public int maxEnemies = 3; //maximum enemies allowed at once
    public string enemyTag = "Enemy"; //ensure enemy prefab has same tag!

    private float _nextSpawnTime;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= _nextSpawnTime)
        {
            if (GetCurrentEnemyCount() < maxEnemies) //only spawn if under the limit
            {
                SpawnEnemy();
            }

            _nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnEnemy()
    {
        Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = transform.position + new Vector3(randomOffset.x, randomOffset.y, 0);

        Instantiate(guardEnemyPrefab, spawnPosition, Quaternion.identity);
    }

    int GetCurrentEnemyCount() //finds all objects in the scene with the specific tag
    {
        return GameObject.FindGameObjectsWithTag(enemyTag).Length;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
