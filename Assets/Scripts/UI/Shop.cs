using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint[] turrets;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectTurret(int index)
    {
        if (index < 0 || index >= turrets.Length) return;

        Debug.Log($"{turrets[index].name} Selected");
        buildManager.SelectTurretToBuild(turrets[index]);
    }
}
