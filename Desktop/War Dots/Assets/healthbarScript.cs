using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthbarScript : MonoBehaviour
{
    public Transform unRotator, healthpivot, healthbar;
    public SpriteRenderer actualHealthbar;
    float hpRatio;
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void healthbarUpdate(int hp, int maxhp)
    {
        hpRatio = hp * 1f / maxhp;
        healthbar.gameObject.SetActive(true);
        if (hpRatio> 0.5f)
        {
            actualHealthbar.color = new Color((maxhp - hp) * 2f / maxhp, 1f, 0f, 1f);
        }
        else if (hpRatio <= 0.5f)
        {
            actualHealthbar.color = new Color(1f, hp * 2f / maxhp, 0f, 1f);
        }
        healthpivot.localScale = new Vector3(hp * 1f / maxhp, 1, 1);
    }
}
