using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private const int rotation_Speed = 3;
    private GameObject coinObject;
    [SerializeField] private GameObject coinPrefab;
    
    private void Update()
    {
        transform.Rotate(Vector3.up * rotation_Speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    
}
