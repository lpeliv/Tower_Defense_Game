using UnityEngine;

[CreateAssetMenu(fileName = "New Turret", menuName = "Turret/TurretBlueprint")]
public class TurretBlueprint : ScriptableObject
{
    public GameObject prefab;
    public int wood;
    public int metal;
    public int cost;
    public bool isUnlocked;

    public TurretType type;
}

public enum TurretType
{
    Standard,
    //Fire,
    //Laser,
}
