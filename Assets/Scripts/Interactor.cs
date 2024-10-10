//using UnityEngine;

//interface IInteractable
//{
//    public void Interact();
//}

//public class Interactor : MonoBehaviour
//{
//    public Transform InteractorSource;
//    public float InteractRange;
//    private IInteractable currentInteractable;
//    private IInteractable previousInteractable;

//    private void Update()
//    {
//        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);

//        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
//        {
//            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
//            {
//                if (currentInteractable != interactObj)
//                {
//                    //CheckCurrentInteractable();
//                    currentInteractable = interactObj;
//                    currentInteractable.Interact();
//                }
//            }
//            //If ray hits an object that isn't interactable, reset the highlight
//            else
//            {
//                CheckCurrentInteractable();
//            }
//        }
//        //If ray doesn't hit anything, reset the highlight
//        else
//        {
//            CheckCurrentInteractable();
//        }

//    }

//    private void CheckCurrentInteractable()
//    {
//        if (currentInteractable != null)
//        {
//            if (currentInteractable is NodeImproved node)
//            {
//                node.ResetColor();
//            }
//            currentInteractable = null;
//        }
//    }
//}


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
            //Flickering when moving, while looking at same node, fix it in future
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