using UnityEngine;
using UnityEngine.UI;

public class MaterialShop : NPCShop
{
    public int woodCost = 20;
    public int woodGain = 10;
    public int metalCost = 10;
    public int metalGain = 5;

    public TurretBlueprint standardTurret;
    public Button standardTurretButton;
    public TurretBlueprint anotherTurret;
    public Button anotherTurretButton;

    public void AddWood()
    {
        if (PlayerStats.Money >= woodCost)
        {
            PlayerStats.Money -= woodCost;
            PlayerStats.Wood += woodGain;
        }
    }

    public void AddMetal()
    {
        if (PlayerStats.Money >= metalCost)
        {
            PlayerStats.Money -= metalCost;
            PlayerStats.Metal += metalGain;
        }
    }

    public void UnlockStandardTurret(Button clickedButton)
    {
        if(PlayerStats.Money >= standardTurret.cost)
        {
            standardTurret.isUnlocked = true;
            standardTurretButton.gameObject.SetActive(true);
            PlayerStats.Money -= standardTurret.cost;

            RemoveButton(clickedButton);
        }
    }

    public void UnlockAnotherTurret(Button clickedButton)
    {
        if (PlayerStats.Money >= anotherTurret.cost)
        {
            anotherTurret.isUnlocked = true;
            anotherTurretButton.gameObject.SetActive(true);
            PlayerStats.Money -= anotherTurret.cost;

            RemoveButton(clickedButton);
        }
    }

    private void RemoveButton(Button button)
    {
        button.interactable = false;
        button.gameObject.SetActive(false);
    }
}