
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;
    protected GameObject spawnedObject;

    public virtual void Spawn()
    {
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }
        
        spawnedObject = Instantiate(prefabToSpawn, transform);
    }
}
