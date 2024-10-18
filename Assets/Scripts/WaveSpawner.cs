using UnityEngine;
using System.Collections;

// Spawner needs to be improved, multiple different enemies have to spawn in same wave,
// add a random spawn location so enemies don't overlap, activate different Wave Spawner
// according to the wave number

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5.5f;
    private float countdown = 2.5f;
    public float timeBetweenEnemies = 0.5f;

    public float spawnOffsetX = 2f;
    public float spawnOffsetZ = 2f;

    //Removed the countdown display for now
    //public TextMeshProUGUI waveCountdownText;

    private int waveIndex = 0;

    private void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }    

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        //waveCountdownText.text = string.Format(CultureInfo.InvariantCulture, "{0:00.00}", countdown);
    }

    //Multiple enemies can be spawned from the same spawner
    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.enemies.Length; i++) 
        {
            for (int j = 0; j < wave.enemies[i].count; j++)
            {
                SpawnEnemy(wave.enemies[i].enemy);
                EnemiesAlive++;
                yield return new WaitForSeconds(1f / wave.spawnRate);
            }
        }
        
        waveIndex++;

        if(waveIndex == waves.Length)
        {
            Debug.Log("Level finished!");
            this.enabled = false;
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        float offsetX = Random.Range(-spawnOffsetX, spawnOffsetX);
        float offsetZ = Random.Range(-spawnOffsetZ, spawnOffsetZ);

        Vector3 spawnPosition = spawnPoint.position + new Vector3(offsetX, 0, offsetZ);
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
