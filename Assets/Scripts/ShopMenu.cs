using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    public GameObject ui;
    public MouseLook mouseLookScript;

    private void Update()
    {
        if (!GameManager.GameIsOver && Input.GetKeyDown(KeyCode.E))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);
        if (ui.activeSelf)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            mouseLookScript.enabled = false;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            mouseLookScript.enabled = true;
        }
    }
}
