using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class HammerShop : NPCShop
{
    public GameObject hammerObject;
    public GameObject hammerUpgradePrefab;
    public string requiredGemName;

    public void TryUpgradeHammer(Button buttonClicked)
    {
        PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();
        bool hasGem = false;
        Loot requiredGem = null;

        foreach (var item in playerInventory.InventoryDictionary)
        {
            if(item.Key.itemName == requiredGemName)
            {
                hasGem = true;
                requiredGem = item.Key;
                break;
            }
        }

        if(hasGem)
        {
            //When upgrading, new object would be set to visible
            hammerObject = Instantiate(hammerUpgradePrefab, hammerObject.transform.position, Quaternion.identity);

            if(requiredGem != null)
            {
                playerInventory.RemoveItem(requiredGem, 1);
            }
            Debug.Log("Hammer upgraded.");
        }
        else
        {
            Debug.Log("Gem is missing.");
        }

    }
}
