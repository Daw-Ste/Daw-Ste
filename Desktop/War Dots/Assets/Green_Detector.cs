using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green_Detector : MonoBehaviour
{
    public Movement this_soldier_movement;
    public CircleCollider2D collider_detector;
    int times_radius_updated;

    private void FixedUpdate()
    {
            if (times_radius_updated<=40&& this_soldier_movement.enemy!=null&& this_soldier_movement.enemy.GetComponent<Soldier_Stats>().target_priority<3)
            {
                collider_detector.radius = (times_radius_updated *Mathf.Sqrt(times_radius_updated)/4 );
                times_radius_updated++;
            }
        //Update 26.01.2022 7:30, do wyjebania jak będzie szwankować

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
            if (this_soldier_movement.locked_on_target!=true&&(this_soldier_movement.enemy==null || (collision.GetComponent<Soldier_Stats>().target_priority > this_soldier_movement.enemy.GetComponent<Soldier_Stats>().target_priority)))
            {
            this_soldier_movement.enemy = collision.gameObject;
                times_radius_updated = 0;//Update 26.01.2022 7:30, do wyjebania jak będzie szwankować
            }
        /*else if (collision.gameObject.CompareTag("Red") && collision.gameObject != this_soldier_movement.enemy_base && (this_soldier_movement.enemy == this_soldier_movement.enemy_base) || (this_soldier_movement.enemy == null))//
        {      //              
            this_soldier_movement.enemy = collision.gameObject;
            times_radius_updated = 0;
        }*/      
    }
}
