using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float spawn_multiplier=1, finalMultiplier=1, timeToFinalMultiplier;
    public GameObject friendbase, GameManager;
    public Transform spawnpoint, spawnLoadingBar;
    public Transform[] Soldier;
    public float[] timetospawn;
    float t=0, t2=0;
    int wave=0;


    public int SpawnTheSoldier(int x)
    {
        Transform soldierclone = Instantiate(Soldier[x], spawnpoint.transform.position, Quaternion.identity);
        soldierclone.GetComponent<Movement>().enemy_base = friendbase;
        if (GameManager != null)
            soldierclone.GetComponent<Soldier_Stats>().GameManager = GameManager;

        if(wave<Soldier.Length-1)
        {
            wave++;
        }
        else
        {
            wave = 0;
        }
        t= 0;
        return 0;
    }

    private void FixedUpdate()
    {
        if (t < timetospawn[wave])
        { 
            t += Time.deltaTime * spawn_multiplier; 
            if(spawnLoadingBar!=null)
            spawnLoadingBar.localScale = new Vector3(t * 1f / timetospawn[wave], 1, 1);
        }
        else
        {          
            SpawnTheSoldier(wave);
        }
        if(t2<timeToFinalMultiplier)
        {
            spawn_multiplier = 1+t2 / timeToFinalMultiplier * (finalMultiplier-1);
            t2 += Time.deltaTime;
        }else if(t2>=timeToFinalMultiplier)
        {
            spawn_multiplier = finalMultiplier;
        }
        if (!friendbase)
            this.enabled = false;
    }
}
