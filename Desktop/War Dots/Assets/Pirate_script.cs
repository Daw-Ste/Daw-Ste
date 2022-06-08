using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate_script : MonoBehaviour
{
    public float range_pistol, range_sword, distance, swingtime, shot_reload, missilespeed;
    public Transform missile_spawn, gunshot_particle;
    float timelefttoshoot;
    public GameObject soldier, sword_collider;
    bool aimed_at_target, unit_attacking;
    public Rigidbody2D missile;
    public Animator Unit_animator;
    public AudioClip pistol_shoot_effect;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void TurnOffAttack()
    {
        unit_attacking = false;
        Unit_animator.SetBool("attacking", false);
        Unit_animator.SetBool("shooting", false);
    }
    public void Pirate_shoot()
    {
        Rigidbody2D missileclone;

        missileclone = Instantiate(missile, missile_spawn.position, transform.rotation);
        missileclone.GetComponent<Missile_Script>().dmg = soldier.GetComponent<Soldier_Stats>().dmg*4;
        missileclone.velocity = transform.TransformDirection(Vector3.up * missilespeed);
        missileclone.GetComponent<Missile_Script>().shooter = soldier.GetComponent<Soldier_Stats>();
        Transform gunshot_effect = Instantiate(gunshot_particle, missile_spawn.position, Quaternion.identity);
        gunshot_effect.localEulerAngles = new Vector3(soldier.transform.localEulerAngles.z - 90, -90, -90);

        AudioSource.PlayClipAtPoint(pistol_shoot_effect, (this.transform.position));        
    }
    public void Pirate_collider_switch(int x)
    {
        if (x ==1)
        {
            sword_collider.SetActive(true);
        }
        else
        {
            sword_collider.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        distance = soldier.GetComponent<Movement>().distance;
        aimed_at_target = soldier.GetComponent<Movement>().aimed_at_target;
        if (distance < range_pistol && unit_attacking == false && aimed_at_target == true&&timelefttoshoot<0)
        {
            unit_attacking = true;
            Unit_animator.SetBool("shooting", true);
            timelefttoshoot = shot_reload;
            soldier.GetComponent<Movement>().locked_on_target = true;
        }
        else if(distance < range_sword && unit_attacking == false && aimed_at_target == true)
        {
            unit_attacking = true;
            Unit_animator.SetBool("attacking", true);
            Unit_animator.SetFloat("Swingtime", swingtime);
            sword_collider.GetComponent<MeleeWeaponHit_Script>().dmg = soldier.GetComponent<Soldier_Stats>().dmg;
            sword_collider.GetComponent<MeleeWeaponHit_Script>().hitOnce = false;
        }
        timelefttoshoot-=Time.deltaTime;
    }
}
