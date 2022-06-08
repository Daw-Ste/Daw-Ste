using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySoldiersByID : MonoBehaviour
{
    public int IdToDestroy;
    public Transform thunder;
    public ParticleSystem thunderHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            Soldier_Stats enemy = collision.GetComponent<Soldier_Stats>();
        if (enemy.unitID == IdToDestroy)
        {
            enemy.TakeDamage(9999, null);
            Transform thunderclone = Instantiate(thunder, enemy.transform.position, Quaternion.identity);
            ParticleSystem particleClone = Instantiate(thunderHit, enemy.transform.position, Quaternion.identity);
        }
    }
    private void LateUpdate()
    {
        this.enabled = false;
    }
}
