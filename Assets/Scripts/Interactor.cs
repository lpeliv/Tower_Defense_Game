using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;
    public LayerMask LayerMask;

    private IInteractable currentInteractable;

    public TurretUI ui;

    private void Update()
    {
        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                interactObj.Interact();

                if(currentInteractable != interactObj)
                {
                    CallColorReset();
                    currentInteractable = interactObj;
                }
            }
            else
            {
                CallColorReset();
                currentInteractable = null;
            }
        }
        else
        {
            CallColorReset();
            currentInteractable = null;
        }
    }

    public void CallColorReset()
    {
        if (currentInteractable is NodeImproved node)
        {
            node.ResetColor();
        }
    }
}