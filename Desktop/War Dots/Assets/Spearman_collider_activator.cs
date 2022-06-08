using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spearman_collider_activator : MonoBehaviour
{
    public void Spearman_collider_switch(int x)
    {
        if (x == 1)
        {
            this.gameObject.GetComponent<Spearman_script>().SpearCollider.SetActive(true);
        }
        else
        {
            this.gameObject.GetComponent<Spearman_script>().SpearCollider.SetActive(false);
        }
    }
}
