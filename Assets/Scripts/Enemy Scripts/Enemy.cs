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
    [SerializeField] private bool canMove = true;
    [SerializeField] private float speed = 1f;
    [SerializeField] private Rigidbody2D enemyRb;
    private bool isMovingRight = true;
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

    public virtual void DealDamage(int damage) { }

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
        enemyRb.velocity = new Vector2( isMovingRight ? speed : -speed, enemyRb.velocity.y);
    }
    
    private void FlipEnemy()
    {
        isFacingRight = !isFacingRight;
        Vector2 enemyLocalScale = transform.localScale;
        enemyLocalScale.x *= -1;
        transform.localScale = enemyLocalScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("EnemyBoundary"))
        {
            isMovingRight = !isMovingRight;
            FlipEnemy();
        }
    }
}
