using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceOpacity : MonoBehaviour
{
    public SpriteRenderer sprite;
    public float timetoFade;
    float t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(t<timetoFade)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1 - t / timetoFade);
            t += Time.deltaTime;
        }
    }
}
