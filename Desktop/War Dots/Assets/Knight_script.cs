using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_script : MonoBehaviour
{
    public float range_charge, range_normal, distance, swingtime, acceleration, chargespeed, basespeed, speed, charge_multiplier;
    public GameObject soldier, lance_collider, charge_collider;
    bool aimed_at_target, unit_attacking;
    public Animator Unit_animator;
    private Movement movement;
    private void Start()
    {
        basespeed = soldier.GetComponent<Movement>().movespeed;
    }
    public void TurnOffAttack()
    {
        unit_attacking = false;
        Unit_animator.SetBool("attacking", false);
        Unit_animator.SetBool("charge_attacking", false);
    }
    public void Knight_charge_collider_switch(int x)
    {
        if (x == 1)
        {
            charge_collider.SetActive(true);
        }
        else
        {
            movement.movespeed = basespeed;
            charge_collider.SetActive(false);
        }
    }
    public void Knight_attack_collider_switch(int x)
    {
        if (x == 1)
        {
            lance_collider.SetActive(true);
        }
        else
        {
            movement.movespeed = basespeed;
            lance_collider.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        movement = soldier.GetComponent<Movement>();
        distance = movement.distance;
        aimed_at_target = movement.aimed_at_target;
        speed = movement.movespeed;
        if (distance > range_charge && speed < chargespeed)
        {
            movement.movespeed += acceleration * Time.deltaTime;
        }


        if (speed>=chargespeed&& distance < range_charge && unit_attacking == false && aimed_at_target == true)
        {
            unit_attacking = true;
            Unit_animator.SetBool("charge_attacking", true);
            Unit_animator.SetFloat("Swingtime", swingtime);
            charge_collider.GetComponent<MeleeWeaponHit_Script>().dmg = (int) (charge_multiplier*soldier.GetComponent<Soldier_Stats>().dmg) ;
            charge_collider.GetComponent<MeleeWeaponHit_Script>().hitOnce = false;
            movement.locked_on_target = true;
            //movement.movespeed = basespeed;
        }else if(speed<chargespeed&&distance<range_normal&&unit_attacking==false&&aimed_at_target==true)
        {
            unit_attacking = true;
            Unit_animator.SetBool("attacking", true);
            Unit_animator.SetFloat("Swingtime", swingtime);
            lance_collider.GetComponent<MeleeWeaponHit_Script>().dmg = soldier.GetComponent<Soldier_Stats>().dmg;
            lance_collider.GetComponent<MeleeWeaponHit_Script>().hitOnce = false;
            //movement.movespeed = basespeed;
        }

    }
}
