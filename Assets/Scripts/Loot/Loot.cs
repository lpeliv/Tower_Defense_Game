using UnityEngine;

[CreateAssetMenu]
public class Loot : ScriptableObject
{
    public GameObject itemPrefab;
    public string itemName;
    public float dropChance;
    public int value;
    //This might be used to group items based by level of appearance
    //(e.g. drops from stage one can be sold or used to craft in other stages)
    //public string category;
}
