using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LootBag : MonoBehaviour
{
    public List<Loot> lootList = new List<Loot>();

    private Loot GetDroppedItem()
    {
        float totalWeight = 0;
        foreach (var loot in lootList)
        {
            totalWeight += loot.dropChance;
        }

        float randomValue = Random.Range(0, totalWeight);

        float cumulativeWeight = 0;
        foreach (var loot in lootList)
        {
            cumulativeWeight += loot.dropChance;
            if(randomValue <= cumulativeWeight)
            {
                return loot;
            }
        }
        return null;
    }

    public void DropLoot(Vector3 spawnPosition)
    {
        Loot droppedItem = GetDroppedItem();
        if(droppedItem != null && droppedItem.itemName != null) 
        {
            Instantiate(droppedItem.itemPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {

        }
    }
}
