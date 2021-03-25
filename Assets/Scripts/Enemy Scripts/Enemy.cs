using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] protected int health = 3;
    [SerializeField] private bool canBeKilled = true;
    [SerializeField] private bool instantKill = false;
    protected float deathTime = 0.5f;

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
        Destroy(gameObject);
    }
}
