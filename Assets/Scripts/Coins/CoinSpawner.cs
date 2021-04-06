using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : Spawner
{
    // Start is called before the first frame update
    void Start()
    {
        GameController.instance.CoinSpawners.Add(this);
    }
}
