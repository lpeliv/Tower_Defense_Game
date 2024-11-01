using UnityEngine;

[System.Serializable]
public class LootItem
{
    public int id;
    public string itemName;
    public GameObject itemPrefab;
    public float dropChance;
    public int minQuantity = 1;
    public int maxQuantity = 5;
    public int value = 0;
    public int type = 0;
}
