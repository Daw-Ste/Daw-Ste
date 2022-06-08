using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poisonedScript : MonoBehaviour
{
    Soldier_Stats thisSoldier;
    // Start is called before the first frame update
    void Start()
    {
        thisSoldier = this.GetComponent<Soldier_Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        thisSoldier.TakeDamage(1, null);
    }
}
