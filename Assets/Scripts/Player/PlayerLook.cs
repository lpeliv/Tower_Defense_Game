using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform playerCamera;
    public Vector2 sensitivities;

    private Vector2 XYRotation;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Vector2 MouseInput = new Vector2
        {
            x = Input.GetAxis("Mouse X"),
            y = Input.GetAxis("Mouse Y")
        };

        XYRotation.x -= MouseInput.y * sensitivities.y;
        XYRotation.y += MouseInput.x * sensitivities.x;

        XYRotation.x = Mathf.Clamp(XYRotation.x, -90f, 90f);

        transform.eulerAngles = new Vector3(0f, XYRotation.y, 0f);
        playerCamera.localEulerAngles = new Vector3(XYRotation.x, 0f, 0f);
    }
}
