using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("EnemyData")]
    public EnemyData enemyData;
    
    private float health;

    [Header("References")]
    public Image healthBar;

    void Start()
    {
        InitializeEnemy();
    }

    private void InitializeEnemy()
    {
        health = enemyData.startHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        if(healthBar != null)
        {
            healthBar.fillAmount = health / enemyData.startHealth;
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        DropLoot();

        if(enemyData.deathEffect != null)
        {
            GameObject effect = Instantiate(enemyData.deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 3f);
        }

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }

    private void DropLoot()
    {
        foreach(var loot in enemyData.lootList)
        {
            float dropChance = loot.dropChance;
            if(Random.value <= dropChance)
            {
                Instantiate(loot.itemPrefab, transform.position, Quaternion.identity);
            }
        }
    }

    public void EndPath()
    {
        PlayerStats.Lives -= enemyData.damage;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("FinishingPoint"))
        {
            EndPath();
        }
    }
}
