using UnityEngine;
using System.Collections;
using TMPro;
using System.Globalization;

// Spawner needs to be improved, multiple different enemies have to spawn in same wave,
// add a random spawn location so enemies don't overlap, activate different Wave Spawner
// according to the wave number

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5.5f;
    private float countdown = 2.5f;
    public float timeBetweenEnemies = 0.5f;

    public TextMeshProUGUI waveCountdownText;

    private int waveIndex = 0;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }    

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format(CultureInfo.InvariantCulture, "{0:00.00}", countdown);
    }

    // Should be implemented --> array of waves with enemy types and other specifics
    IEnumerator SpawnWave()
    {
        waveIndex++;
        PlayerStats.Rounds++;

        for (int i = 0; i < waveIndex; i++) 
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
