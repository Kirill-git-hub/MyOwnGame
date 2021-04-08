using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Spawner
{
    private const int rotation_Speed = 3;
    private static int coin;

    private void Start()
    {
        coin = 0;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * rotation_Speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            coin += 1;
        }
    }
}
