using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsData : MonoBehaviour
{
    [SerializeField] private int coinDenomination;

    public int CoinDenomination
    {
        get => coinDenomination;
    }
}
