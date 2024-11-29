using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsInventory : PlayerInventory
{
    private Dictionary<string, int> materials = new Dictionary<string, int>();

    public void AddMaterial(string materialType, int amount)
    {
        if (materials.ContainsKey(materialType))
        {
            materials[materialType] = +amount;
        }
        else
        {
            materials[materialType] = amount;
        }

        Debug.Log($"Added {amount} of {materialType}. Total: {materials[materialType]}");
    }

    public int GetMaterialCount(string materialType)
    {
        return materials.ContainsKey(materialType) ? materials[materialType] : 0;
    }
    //public void DisplayMaterials() 
    //{
    //    Debug.Log("Materials Inventory:");
    //    foreach(var material in materials)
    //    {
    //        Debug.Log($"{material.Key}: {material.Value}");
    //    }
    //}
}
