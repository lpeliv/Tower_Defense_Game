using Unity.VisualScripting;
using UnityEngine;

//This will be used for all player characteristics, health, damage, speed, etc.
public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;
    
    //This will be connected to BaseHealth combined with PlayerHealth in future
    public static int Lives;
    public int startLives = 10;

    //A completely new logic will be introduced to how enemies spawn according to round number
    public static int Rounds;

    public static int Wood;
    public int startWood;

    public static int Metal;
    public int startMetal;

    public static int Drops;
    public int startDrops;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
        Wood = startWood;
        Metal = startMetal;
        Drops = startDrops;
    }

    public void AddMoney(int amount)
    {
        Money += amount;
    }

    public void AddDrop()
    {
        Drops++;
    }
}
