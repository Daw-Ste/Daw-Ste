using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleDeath : MonoBehaviour
{
    public float timetodie;
    float timesincespawn;

    void Update()
    {
        if (timesincespawn >= timetodie)
        {
            Destroy(this.gameObject);
        } else
            timesincespawn += Time.deltaTime;
    }
}
