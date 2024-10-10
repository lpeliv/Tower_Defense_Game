using UnityEngine;

//Entire BuildManager will have to be adjusted so player can build only when
//in 1st person, not 3rd person
public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one BuldManager in scene!");
            return;
        }
        instance = this;
    }

    //This name shall be changed in the future for consistency
    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;
    
    private TurretBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn(NodeImproved node)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret build! Money left: " + PlayerStats.Money);
    }

    public void SelectTurretToBuild(TurretBlueprint turret) 
    { 
        turretToBuild = turret;
    }

}
