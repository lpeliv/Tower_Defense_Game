using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    public GameObject ui;
    public MouseLook mouseLookScript;
    public GameObject blueprintPrefab;
    public GameObject hammerPrefab;
    public bool isShopMenuOpened;
    
    private void Start()
    {
        mouseLookScript.enabled = true;
        isShopMenuOpened = false;
    }

    private void Update()
    {
        if (!GameManager.GameIsOver && Input.GetKeyDown(KeyCode.B))
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
            hammerPrefab.SetActive(false);
            blueprintPrefab.SetActive(true);
            isShopMenuOpened = true;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            mouseLookScript.enabled = true;
            hammerPrefab.SetActive(true);
            blueprintPrefab.SetActive(false);
            isShopMenuOpened = false;
        }
    }
}
