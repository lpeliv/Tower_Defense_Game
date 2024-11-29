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

    //[Header("Loot Drops")]
    //public LootItem[] lootTable;

    [HideInInspector]
    public float speed;

    [Header("References")]
    public GameObject deathEffect;
    public Image healthBar;
    private LootBag lootBag;

    void Start()
    {
        speed = startSpeed;
        health = startHealth;

        lootBag = GetComponent<LootBag>();
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
        lootBag?.DropLoot(transform.position);

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
}
