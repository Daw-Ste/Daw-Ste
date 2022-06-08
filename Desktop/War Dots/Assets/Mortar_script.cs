using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mortar_script : MonoBehaviour
{
    public float range, distance, shot_delay;
    public GameObject soldier;
    public ScaleChange_airborne missile;
    public Animator mortarAnimator;
    public float timelefttoshot;
    public bool aimed_at_target, prepared;
    public AudioClip shootSound;
    float t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        distance = soldier.GetComponent<Movement>().distance;
        aimed_at_target = soldier.GetComponent<Movement>().aimed_at_target;

        if (distance < range && aimed_at_target == true && prepared == true)
        {
            mortarAnimator.SetBool("attacking", true);
            mortarAnimator.SetBool("attack_ready", false);
            prepared = false;
            timelefttoshot = shot_delay;
        }

        if (timelefttoshot > 0)
        {
            timelefttoshot -= Time.deltaTime;
        }
        else if (timelefttoshot <= 0)
        {
            mortarAnimator.SetBool("attack_ready", true);
            prepared = true;
        }
    }
    public void Mortar_Shoot()
    {
        ScaleChange_airborne missileclone;
        missileclone = Instantiate(missile, transform.position, transform.rotation);
        missileclone.dmg = soldier.GetComponent<Soldier_Stats>().dmg;
        if(distance<=range)
        { 
            missileclone.movespeed = distance; 
        }
        else
            missileclone.movespeed = range;

        //missileclone.squeeze = 160 / distance;

        AudioSource.PlayClipAtPoint(shootSound, (this.transform.position));       
    }
    public void MortarStop()
    {
        mortarAnimator.SetBool("attacking", false);
    }
}
