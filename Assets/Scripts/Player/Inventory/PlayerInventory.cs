using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

[System.Serializable]
public class InventoryItem
{
    public Loot item;
    public int quantity;
}
public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private List<InventoryItem> inventoryList = new List<InventoryItem>();

    public PlayerStats stats;
    //public Dictionary<Loot, int> inventory = new Dictionary<Loot, int>();
    public Dictionary<Loot, int> InventoryDictionary
    {
        get
        {
            Dictionary<Loot, int> dictionary = new Dictionary<Loot, int>();
            foreach(var inventoryItem in inventoryList)
            {
                dictionary[inventoryItem.item] = inventoryItem.quantity;
            }
            return dictionary;
        }
    }

    public void AddItem(Loot item)
    {
        InventoryItem inventoryItem = inventoryList.FirstOrDefault(i => i.item == item);
        if(inventoryItem != null)
        {
            inventoryItem.quantity++;
        }
        else
        {
            inventoryList.Add(new InventoryItem { item = item, quantity = 1});
        }

        if (stats != null)
        {
            stats.AddDrop();
        }
    }

    public Dictionary<string, int> GetInventorySummary()
    {
        return InventoryDictionary.ToDictionary(item => item.Key.itemName, item => item.Value);
    }

    public bool HasItem(Loot item)
    {
        return InventoryDictionary.ContainsKey(item) && InventoryDictionary[item] > 0;
    }

    //for removing items when crafting, implementing in future
    public bool RemoveItem(Loot item, int quantity)
    {
        if(HasItem(item))
        {
            InventoryItem inventoryItem = inventoryList.FirstOrDefault(i => i.item == item);
            if(inventoryItem != null)
            {
                inventoryItem.quantity -= quantity;

                if (inventoryItem.quantity <= 0)
                {
                    inventoryList.Remove(inventoryItem);
                }
                return true;
            }
            
        }
        return false;
    }
}