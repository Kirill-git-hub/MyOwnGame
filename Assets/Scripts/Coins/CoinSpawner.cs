using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : Spawner
{
    private Coin coin;

    void Start()
    {
        GameController.instance.CoinSpawners.Add(this);
        Spawn();
    }

    public override void Spawn()
    {
        base.Spawn();

        coin = spawnedObject.GetComponent<Coin>();
        coin.CoinDenomination = RandomCoinDenomination();
    }

    private int RandomCoinDenomination()
    {
        int randomDenomination = Random.Range(1,5);

        return randomDenomination;
    }
}
