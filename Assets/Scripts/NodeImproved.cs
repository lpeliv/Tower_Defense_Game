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
        rend.material.color = hoverColor;
    }

    //Commented code has to be readjusted for the new Raycasting method 
    //for user interaction with turret building
    //private void OnMouseEnter()
    //{
    //    if (EventSystem.current.IsPointerOverGameObject())
    //        return;

    //    if (!buildManager.CanBuild)
    //    {
    //        return;
    //    }

    //    if (buildManager.HasMoney)
    //    {
    //        rend.material.color = hoverColor;
    //    }
    //    else
    //    {
    //        rend.material.color = notBuildable;
    //    }
    //}
    //private void OnMouseDown()
    //{
    //    if (EventSystem.current.IsPointerOverGameObject())
    //        return;

    //    if (!buildManager.CanBuild)
    //    {
    //        return;
    //    }

    //    if (turret != null)
    //    {
    //        rend.material.color = startColor;
    //        Debug.Log("Can't build there! - TODO: Display on screen.");
    //        return;
    //    }

    //    buildManager.BuildTurretOn(this);
    //}
    //private void OnMouseExit()
    //{
    //    rend.material.color = startColor;
    //}
}
