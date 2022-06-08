using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerWarmup : MonoBehaviour
{
    //this script can only be used on object with script "EnemySpawner"
    [SerializeField]
    private EnemySpawner thisEnemySpawner;
    public float WarmupTime;
    float t;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if(t<WarmupTime)
        {
            t += Time.deltaTime;
        }
        else
        {
            thisEnemySpawner.enabled = true;
            this.enabled = false;
        }
    }
}
