using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movespeed = 1, movespeedMultiplier = 1, range=4, maxrange, distance, rotatespeed=360;
    public GameObject  enemy, enemy_base;
    public Transform rightnav, leftnav, horse_archer_horse,compass;
    public bool aimed_at_target, horse_archer_testing, locked_on_target;
    Transform dot_transform;
    bool circling_the_enemy=false;
    float directionchangecooldown, enemy_size, Leftnav_distance, Rightnav_distance;
    // Start is called before the first frame update
    void Start()
    {
        dot_transform = this.transform;
        if(enemy_base)
        LookAt2D(this.transform, enemy_base.transform);
    }

    // Update is called once per frame
    private void FixedUpdate()    
    {
        if (enemy_base != null)//zniszczenie bazy kończy grę, nie ma sensu żeby jednostka się ruszała po zakończeniu
        {


            if (enemy == null || enemy.GetComponent<Soldier_Stats>().alive == false)
            {
                locked_on_target = false;
                enemy = enemy_base;
            }
            Leftnav_distance = (leftnav.position - enemy.transform.position).magnitude;//zmienić sqrMagnitude na magnitude jakby coś nie działało
            Rightnav_distance = (rightnav.position - enemy.transform.position).magnitude;//zmienić sqrMagnitude na magnitude jakby coś nie działało
            distance = (dot_transform.position - enemy.transform.position).magnitude;
            enemy_size = enemy.GetComponent<Soldier_Stats>().size;
            distance = distance - enemy_size;

            LookAt2D(compass, enemy.transform);
            compass.localEulerAngles = new Vector3(0, 0, compass.localEulerAngles.z);

            if (enemy != enemy_base && distance > maxrange)//zmiana przeciwnika na wrogą bazę, jeżeli przeciwnik jest poza max zasięgiem
            {
                locked_on_target = false;
                enemy = enemy_base;                
            }

         
                dot_transform.rotation = Quaternion.RotateTowards(dot_transform.rotation, compass.transform.rotation, rotatespeed * Time.deltaTime);

            if ((Leftnav_distance <= Rightnav_distance + 0.2) && Rightnav_distance <= Leftnav_distance + 0.2) //zmienić sqrMagnitude na magnitude jakby coś nie działało
            {
                aimed_at_target = true;
            }
            else
            {
                aimed_at_target = false;
            }
            if (horse_archer_testing == false)
            {
                if (distance >= range&&movespeedMultiplier>=0)
                {
                    dot_transform.Translate(0, movespeed * Time.deltaTime*movespeedMultiplier, 0);
                }
                else
                {
                    locked_on_target = true;
                }
            }else
            {
                if (distance > range && (circling_the_enemy == false||(circling_the_enemy==true&&directionchangecooldown<=0)))
                {
                    if (directionchangecooldown <= 0 && circling_the_enemy == true)
                    {
                        directionchangecooldown = 0.2f;
                        circling_the_enemy = false;
                    }
                    if(movespeedMultiplier >= 0)
                    dot_transform.Translate(0, movespeed * Time.deltaTime*movespeedMultiplier, 0);  
                    
                    horse_archer_horse.localEulerAngles = new Vector3(0, 0, 0);//faza testu
                    directionchangecooldown -= Time.deltaTime;
                }else 
                {
                    if (directionchangecooldown <= 0 && circling_the_enemy == false)
                    {
                        directionchangecooldown = 0.5f;
                        circling_the_enemy = true;
                    }
                    if(distance<range)
                    locked_on_target = true;
                    if(movespeedMultiplier >= 0)
                    dot_transform.Translate(movespeed * Time.deltaTime*movespeedMultiplier, 0, 0);

                    horse_archer_horse.localEulerAngles = new Vector3(0, 0, -90);                    
                    directionchangecooldown -= Time.deltaTime;
                }
            }

        }
       
        
    }
    void LookAt2D(Transform ally, Transform enemy)
    {
        ally.up = enemy.position - ally.position;
    }
}
