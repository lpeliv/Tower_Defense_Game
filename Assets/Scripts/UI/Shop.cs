using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint anotherTurret;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    //This will be changed in future, entire shop will look different
    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectAnotherTurret()
    {
        Debug.Log("Another Turret Selected");
        buildManager.SelectTurretToBuild(anotherTurret);
    }
}
