using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    
    private GameObject enemyObject;
    
    public void SpawnEnemy()
    {
        if (enemyObject != null)
        {
            Destroy(enemyObject);
        }
        
        enemyObject = Instantiate(enemyPrefab,transform);
    }
}
