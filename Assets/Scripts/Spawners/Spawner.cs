
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;
    private GameObject spawnedObject;
    private Coin coin;
    public void Spawn()
    {
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }
        
        spawnedObject = Instantiate(prefabToSpawn, transform);

        if (spawnedObject.CompareTag("Coin"))
        {
            coin = spawnedObject.GetComponent<Coin>();
            coin.CoinDenomination = Random.Range(2, 6);
        }
    }
}
