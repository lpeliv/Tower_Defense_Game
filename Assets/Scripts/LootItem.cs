using UnityEngine;

[System.Serializable]
public class LootItem
{
    public string itemName;
    public GameObject itemPrefab;
    public float dropChance;
    public int minQuantity = 1;
    public int maxQuantity = 5;
}
