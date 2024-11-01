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

    private ShopMenu shopMenu;
    
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
        shopMenu = FindObjectOfType<ShopMenu>();
    }
    
    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    
    public void Interact()
    {
        if(shopMenu != null && shopMenu.isShopMenuOpened)
        {
            return;
        }


        if (Input.GetMouseButtonDown(1))
        {
            buildManager.CancelBuild();
            ResetColor();
            return;
        }

        //If no turret was selected, player shouldn't build anything
        if (turret != null)
        {
            if(Input.GetMouseButtonDown(0))
            {
                buildManager.SelectNode(this);
            }
            return;
        }

        if (!buildManager.CanBuild)
        {
            ResetColor();
            return;
        }

        if (buildManager.HasMoney)
        { 
            rend.material.color = hoverColor;

            if (Input.GetMouseButtonDown(0))
            {
                buildManager.BuildTurretOn(this);
                ResetColor();
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
