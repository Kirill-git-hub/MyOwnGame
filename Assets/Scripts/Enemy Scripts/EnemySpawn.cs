using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;
    
    [HideInInspector] public GameObject zombieObject;
    public void Spawn()
    {
        zombieObject = Instantiate(zombiePrefab,transform);
    }
}
