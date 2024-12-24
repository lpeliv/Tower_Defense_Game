using UnityEngine;

[System.Serializable]
public class Wave
{
    public float spawnRate;
    public WaveGroup[] enemies;

    public GameObject fog;

    [System.Serializable]
    public class WaveGroup
    {
        public EnemyData enemyData;
        public int count;
        public Transform spawnPoint;
    }
}
