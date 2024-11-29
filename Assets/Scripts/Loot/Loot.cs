using UnityEngine;

[CreateAssetMenu]
public class Loot : ScriptableObject
{
    public GameObject itemPrefab;
    public string itemName;
    public float dropChance;
}
