using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }
}
