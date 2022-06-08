using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeThrower_Script : MonoBehaviour
{
    public float range, distance, shot_delay;
    public GameObject soldier;
    public Transform center_of_axe;
    public Animator AxeThrower_animator;
    public float timelefttoshot;
    public bool aimed_at_target, prepared;
    //   public TMP_Text mineraltext;
    //   int a;
    // Start is called before the first frame update
    void Start()
    {
        timelefttoshot = 0;
        prepared = true;
    }

    public void  AxeThrower_Throw()
    {
        Transform center_clone1;
        Transform center_clone2;
        Soldier_Stats statsSoldier = soldier.GetComponent<Soldier_Stats>();

        center_clone1 = Instantiate(center_of_axe, soldier.transform.position, soldier.transform.rotation);
        center_clone1.GetComponent<ThrowingAxeRotation_script>().axe.GetComponent<Missile_Script>().dmg = statsSoldier.dmg;
        center_clone1.GetComponent<ThrowingAxeRotation_script>().axe.GetComponent<Missile_Script>().shooter = statsSoldier;
        center_clone1.transform.Translate(0,0.48f * range, 0);

        center_clone2 = Instantiate(center_of_axe, soldier.transform.position, soldier.transform.rotation);
        center_clone2.GetComponent<ThrowingAxeRotation_script>().axe.GetComponent<Missile_Script>().dmg = statsSoldier.dmg;
        center_clone2.GetComponent<ThrowingAxeRotation_script>().axe.GetComponent<Missile_Script>().shooter = statsSoldier;
        center_clone2.transform.Translate(0,0.48f * range, 0);
        center_clone2.transform.Rotate(0, 180, 0);
        
        
        AxeThrower_animator.SetBool("attacking", false);
    }

    void Update()
    {
        distance = soldier.GetComponent<Movement>().distance;
        aimed_at_target = soldier.GetComponent<Movement>().aimed_at_target;
       
        if (distance < range && aimed_at_target == true&&prepared==true)
        {
            AxeThrower_animator.SetBool("attacking", true);
            AxeThrower_animator.SetBool("attack_ready", false);
            prepared = false;
            timelefttoshot = shot_delay;
        }

        if (timelefttoshot > 0)
        { 
            timelefttoshot -= Time.deltaTime; 
        }else if (timelefttoshot <= 0)
        {
            AxeThrower_animator.SetBool("attack_ready", true);
            prepared = true;
        }
    }

}
