//This script was created with tutor help
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [Header ("Spawn Settings")]
    public GameObject guardEnemyPrefab;
    public float spawnRate = 2f; 
    public float spawnRadius = 5f;

    [Header ("Limit Settings")]
    public int maxEnemies = 10; //maximum enemies allowed at once
    public string enemyTag = "Enemy"; //ensure enemy prefab has same tag!

    private float _nextSpawnTime;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Spawner Running");
        Debug.Log(GetCurrentEnemyCount());
        if(Time.time >= _nextSpawnTime)
        {
            Debug.Log("Trying to spawn");
            if (GetCurrentEnemyCount() < maxEnemies) //only spawn if under the limit
            {
                SpawnEnemy();
            }

            _nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnEnemy()
    {
        Debug.Log("Spawn enemy function entered");
        if (guardEnemyPrefab == null)
        {
            Debug.Log("ERROR - prefab not assigned");
            return;
        }

        Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;

        Vector3 spawnPosition =
            transform.position +
            new Vector3(randomOffset.x, randomOffset.y, 0);

        //Vector3 spawnPosition = transform.position + new Vector3(randomOffset.x, randomOffset.y, 0);

        Instantiate(guardEnemyPrefab, spawnPosition, Quaternion.identity);

        Debug.Log("Enemy Spawned!");
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
