using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float startSpeed = 10f;
    private float health;
    public float startHealth = 100;
    public int worth = 50;
    public int damage = 1;

    [Header("Loot Drops")]
    public LootItem[] lootTable;

    [HideInInspector]
    public float speed;

    public GameObject deathEffect;

    public Image healthBar;

    void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Disabled for now
        //PlayerStats.Money += worth;
        
        DropLoot();

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }

    public void EndPath()
    {
        PlayerStats.Lives -= damage;
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

    private void DropLoot()
    {
        foreach(LootItem loot in lootTable)
        {
            float randomValue = Random.Range(0f, 100f);
            if(randomValue <= loot.dropChance)
            {
                int quantity = Random.Range(loot.minQuantity, loot.maxQuantity + 1);
                for(int i = 0; i < quantity; i++)
                {
                    Vector3 dropPosition = transform.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f));
                    Instantiate(loot.itemPrefab, dropPosition, Quaternion.identity);
                    Debug.Log($"Dropped {loot.itemName} x{quantity}");
                }
            }
        }
    }
}
