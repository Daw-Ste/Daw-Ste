using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordsman_collider_activator : MonoBehaviour
{
    public void Swordsman_collider_switch(int x)
    {
        if(x==1)
        {
            this.gameObject.GetComponent<Swordsman_Script>().SwordCollider.SetActive(true);
        }
        else
        {
            this.gameObject.GetComponent<Swordsman_Script>().SwordCollider.SetActive(false);
        }
    }
}
