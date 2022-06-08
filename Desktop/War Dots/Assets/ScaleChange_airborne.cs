using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleChange_airborne : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    float starting_scale_multiplier;
    public bool isPlayerMissile;
    public float squeeze=1, movespeed = 10, squash=1, correctingMultiplier=1.02f;
    [SerializeField]
    private bool hasTargetMark;
    float time_since_knockup, knockuptime, newscale;
    public int dmg = 1000;
    // Start is called before the first frame update

    void Start()
    {
        // range=movespeed*knockuptime = movespeed*4/squeeze
        knockuptime = 4 / squeeze;
        if (hasTargetMark)
        {
            Transform targetMark = Instantiate(target, this.transform.position + (movespeed * knockuptime * this.transform.up)*correctingMultiplier, Quaternion.identity);
            artilleryMarkerScript targetMarkScript = targetMark.GetComponent<artilleryMarkerScript>();
            targetMarkScript.timetoDie = knockuptime;
            targetMarkScript.dmg = dmg;
            targetMarkScript.isPlayersMissile = isPlayerMissile;
        }
        starting_scale_multiplier = this.transform.localScale.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        
        if(time_since_knockup<knockuptime)
        {
            newscale=(-((squeeze*time_since_knockup - 2))*((squeeze*time_since_knockup - 2)) + 4)/squash+1;
            newscale *= starting_scale_multiplier;
            this.transform.localScale = new Vector3(newscale, newscale, newscale);
            this.transform.Translate(0, movespeed * Time.deltaTime, 0);
        }else if(time_since_knockup >= knockuptime)
        {
            //GameObject hitEffect = Instantiate(objectToSpawnOnHit, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        time_since_knockup += Time.deltaTime;
    }
}
