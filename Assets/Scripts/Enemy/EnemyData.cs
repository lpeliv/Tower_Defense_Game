using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    [Header("Enemy Properties")]
    public GameObject enemyPrefab;
    public float startSpeed;
    public float startHealth;
    public int worth;
    public int damage;

    [Header("Visuals")]
    public GameObject deathEffect;

    [Header("Loot Settings")]
    public List<Loot> lootList = new List<Loot>();
}
