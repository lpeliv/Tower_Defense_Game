using UnityEngine;
using System.Collections;

// Spawner needs to be improved, add a random spawn location so enemies don't overlap,

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public bool IsSpawning {  get; private set; }

    public Wave[] waves;

    public float timeBetweenWaves = 5.5f;
    public float timeBetweenEnemies = 0.5f;

    public float spawnOffsetX = 2f;
    public float spawnOffsetZ = 2f;

    private int waveIndex = 0;

    private void Update()
    {
        if(EnemiesAlive == 0 && waveIndex >= waves.Length)
        {
            Debug.Log("All waves are complete!");
            this.enabled = false;
        }
    }

    //Multiple enemies can be spawned from the same spawner
    IEnumerator SpawnWave()
    {
        IsSpawning = true;
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.enemies.Length; i++) 
        {
            Wave.WaveGroup waveGroup = wave.enemies[i];

            for (int j = 0; j < wave.enemies[i].count; j++)
            {
                SpawnEnemy(waveGroup.enemy, waveGroup.spawnPoint);
                EnemiesAlive++;
                yield return new WaitForSeconds(1f / wave.spawnRate);
            }
        }
        
        waveIndex++;
        IsSpawning = false;
        if(waveIndex == waves.Length)
        {
            Debug.Log("Level finished!");
            this.enabled = false;
        }
    }

    public void StartNewWave()
    {
        if(EnemiesAlive == 0 && !IsSpawning)
        {
            Debug.Log("Starting new wave...");
            StartCoroutine(SpawnWave());
        }
    }

    void SpawnEnemy(GameObject enemy, Transform spawnPoint)
    {
        float offsetX = Random.Range(-spawnOffsetX, spawnOffsetX);
        float offsetZ = Random.Range(-spawnOffsetZ, spawnOffsetZ);

        Vector3 spawnPosition = spawnPoint.position + new Vector3(offsetX, 0, offsetZ);
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
