using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeleton : Enemy
{
    
    private Rigidbody2D enemyRd;
    private bool faceRight = true;
    private Animator zombieAnim;

    public bool moveRight = true;

    // Start is called before the first frame update
    void Start()
    {
        enemyRd = GetComponent<Rigidbody2D>();
        zombieAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight  )
        {
            enemyRd.velocity = new Vector2(1, enemyRd.velocity.y);  
        }
        else
        {
            enemyRd.velocity = new Vector2(-1, enemyRd.velocity.y);  
        }
    }
    
    void EnemyFlip()
    {
        faceRight = !faceRight;
        Vector2 enemyLocalScale = transform.localScale;
        enemyLocalScale.x *= -1;
        transform.localScale = enemyLocalScale;
    }
    
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.gameObject.CompareTag("EnemyBoundary"))
        {
            if (moveRight)
            {
                moveRight = false;
                EnemyFlip();
            }
            else
            {
                moveRight = true;
                EnemyFlip();
            }
        }
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
