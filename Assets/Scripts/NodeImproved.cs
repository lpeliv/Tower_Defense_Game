using UnityEngine;
public class NodeImproved : MonoBehaviour, IInteractable
{
    [Header("Color settings")]
    public Color hoverColor;
    public Color notBuildable;
    private Color startColor;

    [Header("Optional - for ruins")]
    public GameObject turret;
    
    public Vector3 positionOffset;
    
    private Renderer rend;
    BuildManager buildManager;
    
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }
    
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    
    public void Interact()
    {
        //If no turret was selected, player shouldn't build anything
        if (!buildManager.CanBuild)
        {
            ResetColor();
            return;
        }
        
        if (turret != null)
        {
            rend.material.color = startColor;
            Debug.Log("Can't build there! - TODO: Display on screen.");
            return;
        }

        if (buildManager.HasMoney)
        { 
            rend.material.color = hoverColor;

            if(Input.GetMouseButtonDown(0))
            {
                buildManager.BuildTurretOn(this);
            }
        }

        else
        {
            rend.material.color = notBuildable;
        }
    }

    public void ResetColor()
    {
        rend.material.color = startColor;
    }
}
