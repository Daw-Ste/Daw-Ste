using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms;

public class Archer_Script : MonoBehaviour
{
    public float range, distance, shot_delay, missilespeed;
    public GameObject soldier;
    public Rigidbody2D missile;
    public Animator archer_animator;
    public float timelefttoshot;
    public bool aimed_at_target, prepared;
    public AudioClip bowShootEffect;

    void Start()
    {
        timelefttoshot = 0;
        prepared = true;

    }

    public void Archer_shoot()
    {
        int randomnumber;
        randomnumber = Random.Range(0, 10);
        Rigidbody2D missileclone;
        missileclone = Instantiate(missile, transform.position, transform.rotation);
        missileclone.GetComponent<Missile_Script>().dmg = soldier.GetComponent<Soldier_Stats>().dmg;
        missileclone.GetComponent<Missile_Script>().shooter = soldier.GetComponent<Soldier_Stats>();
        missileclone.velocity = transform.TransformDirection(Vector3.up * missilespeed);
        if (randomnumber == 9)
        {
            missileclone.GetComponent<Missile_Script>().dmg *= 2;
            missileclone.transform.localScale *= 2;
        }
        AudioSource.PlayClipAtPoint(bowShootEffect, (this.transform.position));
        archer_animator.SetBool("attacking", false);
    }

    void Update()
    {
        distance = soldier.GetComponent<Movement>().distance;
        aimed_at_target = soldier.GetComponent<Movement>().aimed_at_target;

        if(distance<range  && aimed_at_target==true && prepared == true)
        {
            archer_animator.SetBool("attacking", true);
            archer_animator.SetBool("attack_ready", false);
            prepared = false;
            timelefttoshot = shot_delay;
        }

        if (timelefttoshot > 0)
        {
            timelefttoshot -= Time.deltaTime;
        }else if (timelefttoshot <= 0)
        {
            archer_animator.SetBool("attack_ready", true);
            prepared = true;
        }
    }
    
}
