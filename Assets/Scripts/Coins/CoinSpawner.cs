using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : Spawner
{
    void Start()
    {
        GameController.instance.CoinSpawners.Add(this);
    }
}
