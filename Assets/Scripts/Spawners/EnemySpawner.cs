﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    void Start()
    {
        GameController.instance.EnemySpawners.Add(this);
    }
}
