using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private int health = 3;
    [SerializeField] private bool canBeKilled = true;
    [SerializeField] private bool instantKill = false;
    [SerializeField] private bool canMove = true;
    [SerializeField] private bool canDealDamage;
    [SerializeField] private float speed = 1f;
    [SerializeField] private Rigidbody2D enemyRb;
    [SerializeField] private Animator enemyAnim;
    private bool isFacingRight = true;
    
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

    public bool CanDealDamage
    {
        get => canDealDamage;
        set => canDealDamage = value;
    }

    public void DealDamage(int damage)
    {
        enemyAnim.SetTrigger("Hit");
        health -= damage;

        if (health <= 0)
        {
            CanDealDamage = false;
            enemyAnim.SetTrigger("DeathTrigger");
            KillEnemy();
        }
    }

    public void KillEnemy()
    {
        Destroy(gameObject, 1.5f);
    }

    private void Update()
    {
        if (canMove)
        {
            MoveEnemy();
        }
    }

    private void MoveEnemy()
    {
        enemyRb.velocity = new Vector2( isFacingRight ? speed : -speed, enemyRb.velocity.y);
    }
    
    private void FlipEnemy()
    {
        Vector2 enemyLocalScale = transform.localScale;
        enemyLocalScale.x *= -1;
        transform.localScale = enemyLocalScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("EnemyBoundary"))
        {
            isFacingRight = !isFacingRight;
            FlipEnemy();
        }
    }
}
