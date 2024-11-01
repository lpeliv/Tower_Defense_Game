using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<LootItem> inventory = new List<LootItem>();
    public PlayerStats stats;

    public void AddItem(LootItem item)
    {
        inventory.Add(item);

        if(stats != null)
        {
            stats.AddDrop();
        }
    }
    
    public Dictionary<int, int> GetInventorySummary()
    {
        return inventory.GroupBy(item => item.id).ToDictionary(group =>  group.Key, group => group.Count());
    }
}
