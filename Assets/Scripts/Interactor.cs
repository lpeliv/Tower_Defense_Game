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

    //In future, this will be changed so color reset happens inside NodeImproved script
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
                ClearCurrentInteractable();
            }
        }
        else
        {
            ClearCurrentInteractable();
        }
    }

    public void CallColorReset()
    {
        if (currentInteractable is NodeImproved node)
        {
            node.ResetColor();
        }
    }

    public void ClearCurrentInteractable()
    {
        CallColorReset();
        currentInteractable = null;
    }
}