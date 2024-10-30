using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;

    public Image playerHealthBar;
    private int maxLives;

    private void Start()
    {
        maxLives = FindObjectOfType<PlayerStats>().startLives;
    }

    private void Update()
    {
        livesText.text = PlayerStats.Lives.ToString();

        float livesPercentage = (float)PlayerStats.Lives / maxLives;

        playerHealthBar.fillAmount = livesPercentage;
    }
}
