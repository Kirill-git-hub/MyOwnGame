using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeleton : Enemy
{
    private Animator zombieAnim;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        zombieAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    public override void DealDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            //zombieAnim.SetBool("Death", true);
            zombieAnim.SetTrigger("DeathTrigger");
            KillEnemy();
        }
        else
        {
            zombieAnim.SetTrigger("Hit");
        }
    }

}
