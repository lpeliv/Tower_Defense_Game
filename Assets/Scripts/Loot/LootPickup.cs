using UnityEngine;

public class LootPickup : MonoBehaviour
{
    public Loot loot;
    public float attractionRange = 200f;
    public float attractionSpeed = 5f;

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
            if (playerInventory != null && loot !=null)
            {
                playerInventory.AddItem(loot);
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
