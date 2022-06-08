using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorker : MonoBehaviour
{
    public ParticleSystem FireWorks;
    float time_until_next_firework;
    public float timebetweenshots;

    void Update()
    {
        if (time_until_next_firework > 0)
        { 
            time_until_next_firework -= Time.deltaTime; 
        }else if(time_until_next_firework<=0)
        {
            ParticleSystem firework = Instantiate(FireWorks, new Vector3((Random.Range(0,2000)-1000)/100, (Random.Range(0, 1000) - 500) / 100, 1), Quaternion.identity);
            time_until_next_firework = timebetweenshots;
        }
    }
}
