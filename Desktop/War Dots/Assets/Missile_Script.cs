using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile_Script : MonoBehaviour
{
    public int dmg;
    public float timetodie;
    public GameObject object_to_destroy;
    public bool penetration;
    float timesincespawn;
    public Transform blood;
    public Soldier_Stats shooter;
    bool hitOnce;
    public AudioClip[] sound_on_hit;
    private void OnTriggerEnter2D(Collider2D collision)   
    {        if (!hitOnce)
        {
            
            collision.gameObject.GetComponent<Soldier_Stats>().TakeDamage(dmg, shooter);

            if (collision.gameObject.GetComponent<Soldier_Stats>().building == false)
            {
                int randomnumber = Random.Range(0, sound_on_hit.Length);
                if(sound_on_hit.Length!=0)
                AudioSource.PlayClipAtPoint(sound_on_hit[randomnumber], (this.transform.position));
                Transform bloodeffect = Instantiate(blood, collision.transform.position, Quaternion.identity);
                bloodeffect.localEulerAngles = new Vector3(this.transform.localEulerAngles.z - 90, -90, -90);

            }
            if (!penetration)
            { 
                hitOnce = true;
                Destroy(object_to_destroy);
            }
                
        }
    }
    private void Update()
    {
        if(timesincespawn>=timetodie)
        { 
            Destroy(object_to_destroy);
        }else
        timesincespawn += Time.deltaTime;

    }
}
