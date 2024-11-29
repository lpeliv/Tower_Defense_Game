using System.Collections.Generic;
using UnityEngine;

public class HammerShop : NPCShop
{
    public GameObject hammerObject;
    public List<GameObject> hammerUpgrades;
    public List<Loot> requiredGems;

    public List<HammerUpgradeStats> upgradeStats;

    public void TryUpgradeHammer(int upgradeIndex)
    {
        PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();

        if(upgradeIndex < 0 || upgradeIndex >= hammerUpgrades.Count || upgradeIndex >= requiredGems.Count)
        {
            Debug.LogWarning("Invalid upgrade index.");
            return;
        }
        Loot requiredGem = requiredGems[upgradeIndex];
        bool hasGem = false;

        foreach (var item in playerInventory.InventoryDictionary)
        {
            if(item.Key.itemName == requiredGem.itemName)
            {
                hasGem = true;
                break;
            }
        }

        if(hasGem)
        {
            hammerUpgrades[upgradeIndex].SetActive(true);

            Hammer hammer = hammerObject.GetComponent<Hammer>();
            if (hammer != null)
            {
                HammerUpgradeStats stats = upgradeStats[upgradeIndex];
                hammer.HammerUpgraded(stats.damage, stats.range, stats.fireRate);
                Debug.Log("UpgradedHammer");
            }

            if (requiredGem != null)
            {
                playerInventory.RemoveItem(requiredGem, 1);
            }
        }
        else
        {
            Debug.Log("Gem is missing.");
        }

    }
}
