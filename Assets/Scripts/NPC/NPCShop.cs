using UnityEngine;

public class NPCShop : MonoBehaviour, IInteractable
{
    public GameObject shopUI;
    public PlayerLook mouseLookScript;
    public PlayerMovementBetter movement;
    public ShopMenu blueprintScript;
    public PauseMenu pauseMenu;
    public GameObject ui;
    public GameObject hammerPrefab;
    public bool isShopMenuOpened;

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Toggle();
        }
    }
    public void Toggle()
    {
        shopUI.SetActive(!shopUI.activeSelf);
        if (shopUI.activeSelf)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            mouseLookScript.enabled = false;
            blueprintScript.enabled = false;
            movement.enabled = false;
            pauseMenu.enabled = false;
            hammerPrefab.SetActive(false);
            ui.SetActive(false);
            isShopMenuOpened = true;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            mouseLookScript.enabled = true;
            blueprintScript.enabled = true;
            movement.enabled = true;
            pauseMenu.enabled = true;
            hammerPrefab.SetActive(true);
            ui.SetActive(true);
            isShopMenuOpened = false;
        }
    }
}
