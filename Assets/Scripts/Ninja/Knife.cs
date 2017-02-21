using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour, IAttackable
{
    Collider2D col;

    [SerializeField]
    int damage;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    public void Attack()
    {
        EnableCollider();
    }

    void EnableCollider()
    {
        col.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageable ableToAttack = collision.GetComponent<IDamageable>();

        if (ableToAttack != null)
            ableToAttack.GetDamage(damage);
    }
}
