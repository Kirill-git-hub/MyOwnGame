using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [SerializeField] private int damage = 1;
    [SerializeField] protected int health = 3;
    [SerializeField] private bool canBeKilled = true;
    [SerializeField] private bool instantKill = false;
    private bool moveRight = true;
    private bool faceRight = true;
    private int speed = 1;
    protected Rigidbody2D enemyRb;
    public int Damage
    {
        get => damage;
    }
    
    public bool CanBeKilled
    {
        get => canBeKilled;
    }

    public bool InstantKill
    {
        get => instantKill;
    }

    public virtual void DealDamage(int damage) { }

    public void KillEnemy()
    {
        Destroy(gameObject, 1.5f);
    }

    protected void EnemyMovement()
    {
        if (moveRight  )
        {
            enemyRb.velocity = new Vector2(speed, enemyRb.velocity.y);  
        }
        else
        {
            enemyRb.velocity = new Vector2(-speed, enemyRb.velocity.y);  
        }
    }
    
    private void EnemyFlip()
    {
        faceRight = !faceRight;
        Vector2 enemyLocalScale = transform.localScale;
        enemyLocalScale.x *= -1;
        transform.localScale = enemyLocalScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("EnemyBoundary"))
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
}
