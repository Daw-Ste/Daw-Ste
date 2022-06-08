using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSpawntimeOfNextSoldier : MonoBehaviour
{
    public LoadingUnit unitQueue;
    public float spawntimeMultiplier;
    // Start is called before the first frame update
    private void Start()
    {
        unitQueue.oneTimeSpawnMultiplier = spawntimeMultiplier;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
