using UnityEngine;

public class LootPickup : MonoBehaviour
{
    public LootItem lootItem;
    public float attractionRange = 200f;
    public float attractionSpeed = 5f;
    public int price = 20;

    private Transform playerTransform;
    private bool isAttracted = false;

    private void Update()
    {
        if(playerTransform != null)
        {
            float distance = Vector3.Distance(transform.position, playerTransform.position);
            if(distance <= attractionRange)
            {
                isAttracted = true;
            }

            if(isAttracted)
            {
                transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, attractionSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTransform = other.transform;
            PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
            if (playerInventory != null)
            {
                playerInventory.AddItem(lootItem);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTransform = null;
            isAttracted = false;
        }
    }
}
