using UnityEngine;

public class DroppedLoot : MonoBehaviour
{
    private float lifespan = 10f;

    private void Start()
    {
        Destroy(gameObject, lifespan);
    }
}