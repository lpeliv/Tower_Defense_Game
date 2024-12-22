using UnityEngine;

public class MonsterDropsShop : NPCShop
{
    public void TrySellItem(Loot lootToSell, int quantity)
    {
        PlayerInventory playerInventory = FindObjectOfType<PlayerInventory>();

        if(playerInventory.InventoryDictionary.TryGetValue(lootToSell, out int currentQuantity) && currentQuantity >= quantity)
        {
            playerInventory.RemoveItem(lootToSell, quantity);
            int totalValue = lootToSell.value * quantity;
            PlayerStats.Money += totalValue;

            Debug.Log($"Sold {quantity}x {lootToSell.itemName} for {totalValue} money!");
        }
        else
        {
            Debug.Log($"Not enough {lootToSell.itemName} to sell.");
        }
    }
}
