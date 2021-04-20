using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private const int ROTATION_SPEED = 150;
    [SerializeField] private int coinDenomination;

    public int CoinDenomination
    {
        get => coinDenomination;
        set => coinDenomination = value;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * (Time.deltaTime * ROTATION_SPEED));
    }

}
