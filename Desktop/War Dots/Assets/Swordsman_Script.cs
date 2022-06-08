using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordsman_Script : MonoBehaviour
{
    public float range, distance, swingtime;
    public GameObject soldier, SwordCollider;
    bool aimed_at_target, unit_attacking;

    public Animator Unit_animator;

    public void TurnOffAttack()
    {
        unit_attacking = false;
        Unit_animator.SetBool("attacking", false);
    }

    void Update()
    {
        distance = soldier.GetComponent<Movement>().distance;
        aimed_at_target = soldier.GetComponent<Movement>().aimed_at_target;
        if (distance < range && unit_attacking == false && aimed_at_target == true)
        {
            unit_attacking = true;
            Unit_animator.SetBool("attacking", true);
            Unit_animator.SetFloat("Swingtime", swingtime);
            SwordCollider.GetComponent<MeleeWeaponHit_Script>().dmg = soldier.GetComponent<Soldier_Stats>().dmg;
            SwordCollider.GetComponent<MeleeWeaponHit_Script>().hitOnce = false;
        }
    }
}
