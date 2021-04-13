using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private int playerHealth = 3;
    [SerializeField] private int increaseCoins = 1;
    private int playerCoins;

    public int IncreaseCoins
    {
        get => increaseCoins;
    }

    public int PlayerCoins
    {
        get => playerCoins;
        set => playerCoins = value;
    }
    
    public int Damage
    {
        get => damage; 
    }

    public int PlayerHealth
    {
        get => playerHealth;
        set => playerHealth = value;
    }

}
