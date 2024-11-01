using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    public PlayerLook mouseLookScript;

    private void Update()
    {
        if (!GameManager.GameIsOver && ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))))
        {
            Toggle();
        }
    }
    
    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);
        if(ui.activeSelf)
        {
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            mouseLookScript.enabled = false;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            mouseLookScript.enabled = true;
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Debug.Log("Go to menu.");
    }
}
