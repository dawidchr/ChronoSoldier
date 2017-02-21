using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : Controller
{
    Rigidbody2D body;
    NinjaStats stats;

    RaycastHit2D ray;

    Action OnAttackAction;
    Action OnTeleportAction;


    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void MoveLeft()
    {
        body.velocity -= new Vector2(stats.movingSpeed * Time.deltaTime, 0f);
    }

    public void MoveRight()
    {
        body.velocity += new Vector2(stats.movingSpeed * Time.deltaTime, 0f);
    }

    public void SwitchMeeleeAndRange()
    {
        stats.MeeleOrDistance();
        
        if(stats.attackOrTeleport)
        {
            if (stats.meeleeWeaponEnabled)
            {
                OnAttackAction = null;
                OnAttackAction += AttackMeele;
            }
            else
            {
                OnAttackAction = null;
                OnAttackAction += AttackRange;
            }
        }
    }

    public void AttackMeele()
    {

    }

    public void AttackRange()
    {

    }

    public void SwitchTeleport()
    {
        stats.SwitchTeleportAndMove();
        OnActionArea = null;

        if (stats.attackOrTeleport)
            OnActionArea = OnAttackAction;
        else
            OnActionArea = OnTeleportAction;
    }

    public void Teleport()
    {

    }
}
