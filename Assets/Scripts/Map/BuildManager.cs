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
    private NodeImproved selectedNode;

    public TurretUI turretUi;
    private ShopMenu shopMenu;
    
    public bool CanBuild { get { return turretToBuild != null && IsBuildAllowed; } }
    public bool HasResources { get { return PlayerStats.Wood >= turretToBuild.wood &&
                                            PlayerStats.Metal >= turretToBuild.metal; } }
    public bool IsBuildAllowed { get; private set; } = true;

    private void Start()
    {
        shopMenu = FindObjectOfType<ShopMenu>();
    }

    public void BuildTurretOn(NodeImproved node)
    {
        if(PlayerStats.Wood < turretToBuild.wood &&
           PlayerStats.Metal < turretToBuild.metal)
        {
            Debug.Log("Not enough materials to build that!");
            return;
        }

        PlayerStats.Wood -= turretToBuild.wood;
        PlayerStats.Metal -= turretToBuild.metal;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        IsBuildAllowed = false;
    }

    public void SelectNode(NodeImproved node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            Debug.Log("Node Deselected");
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        turretUi.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        turretUi.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret) 
    {
        shopMenu.Toggle();
        turretToBuild = turret;
        DeselectNode();
        IsBuildAllowed = true;
    }

    public void CancelBuild()
    {
        turretToBuild = null;
        DeselectNode();
        IsBuildAllowed = false;
        Debug.Log("Build canceled");
    }

}
