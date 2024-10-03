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
    
    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SetTurretToBuild(GameObject turret) 
    { 
        turretToBuild = turret;
    }

}
