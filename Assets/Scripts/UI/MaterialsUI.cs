using TMPro;
using UnityEngine;

public class MaterialsUI : MonoBehaviour
{
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI metalText;
    public TextMeshProUGUI dropsText;

    private void Update()
    {
        woodText.text = PlayerStats.Wood.ToString();
        metalText.text = PlayerStats.Metal.ToString();
        dropsText.text = PlayerStats.Drops.ToString();
    }
}
