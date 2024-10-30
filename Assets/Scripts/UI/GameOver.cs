using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI roundsText;

    private void OnEnable()
    {
        Toggle();
        
        if(PlayerStats.Rounds < 1)
        {
            roundsText.text = PlayerStats.Rounds.ToString();
        }
        roundsText.text = (PlayerStats.Rounds - 1).ToString();
    }

    
    public void Toggle()
    {
        if (GameManager.GameIsOver)
        {
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Debug.Log("Retry pressed.");

        Toggle();
        Debug.Log("Toggle done.");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Time.timeScale = 1f;
        Debug.Log("Scene loaded.");

    }

    public void Menu()
    {
        Debug.Log("Go to menu.");
    }
}
