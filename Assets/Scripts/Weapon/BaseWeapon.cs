using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    public int damage;
    public Action specialAttack;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable dam = collision.gameObject.GetComponent<IDamageable>();
        if (dam != null)
        {
            dam.GetDamage(damage);

            if (specialAttack != null)
                specialAttack();
        }
    }
}
