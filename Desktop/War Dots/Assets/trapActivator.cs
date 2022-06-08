using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapActivator : MonoBehaviour
{
    public amBush[] trap;
    int x;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        while (x < trap.Length)
        {
            trap[x].enabled = true;
            x++;
        }
        this.enabled = false;
    }
}
