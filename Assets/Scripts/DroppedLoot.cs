using UnityEngine;

public class DroppedLoot : MonoBehaviour
{
    private int amount;
    private float lifespan = 10f;

    //private PlayerInventory playerInventory;
    private LootItem lootItem;

    private void Start()
    {
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //if(player != null)
        //{
        //    playerInventory = player.GetComponent<PlayerInventory>();
        //}
        //else
        //{
        //    Debug.LogError("Player GameObject not found.");
        //}

        Destroy(gameObject, lifespan);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        if (playerInventory != null)
    //        {
    //            playerInventory.AddItem(lootItem.itemName, amount);
    //            playerInventory.DisplayInventory();
    //            Destroy(gameObject);
    //        }
    //        else
    //            Debug.Log("No inventory");
    //    }
    //}
}