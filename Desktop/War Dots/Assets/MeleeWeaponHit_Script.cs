using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponHit_Script : MonoBehaviour
{
    public int dmg;
    public bool hitOnce = false, AOE=false;
    public Transform soldier, blood;
    public AudioClip[] sound_on_hit, buildingHitSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {   if (AOE==true || !hitOnce)
        {/*if (dmg > collision.gameObject.GetComponent<Soldier_Stats>().armour)
            collision.gameObject.GetComponent<Soldier_Stats>().hp -= dmg - collision.gameObject.GetComponent<Soldier_Stats>().armour;*/
            if (collision.gameObject.GetComponent<Soldier_Stats>().building == false)
            {
                int randomnumber = Random.Range(0, 3);
                AudioSource.PlayClipAtPoint(sound_on_hit[randomnumber], (this.transform.position));
                Transform bloodeffect = Instantiate(blood, collision.transform.position, Quaternion.identity);
                bloodeffect.localEulerAngles = new Vector3(soldier.localEulerAngles.z-90,-90,-90);
            }
            else if (collision.gameObject.GetComponent<Soldier_Stats>().building == true)
            {
                int randomnumber = Random.Range(0, 2);
                AudioSource.PlayClipAtPoint(buildingHitSound[randomnumber], (this.transform.position));
            }

            collision.gameObject.GetComponent<Soldier_Stats>().TakeDamage(dmg, soldier.GetComponent<Soldier_Stats>() );
            hitOnce = true;
        }

    }
    
}
