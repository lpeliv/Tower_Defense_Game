using UnityEngine;

public class TurretUI : MonoBehaviour
{
    public GameObject ui;

    private NodeImproved target;

    //When player left clicks the note, Turret UI becomes active
    public void SetTarget(NodeImproved _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
}
