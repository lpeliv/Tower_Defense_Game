using UnityEngine;

public class BillBoard : MonoBehaviour
{
    private void Update()
    {
        transform.forward = Camera.main.transform.forward;
        //transform.LookAt(Camera.main.transform.position, -Vector3.up);
    }
}
