using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<LootItem> inventory = new List<LootItem>();

    public void AddItem(LootItem item)
    {
        inventory.Add(item);
        Debug.Log($"{item.itemName} added to inventory.");
    }
}
