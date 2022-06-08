using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOuter : MonoBehaviour
{
    float t;
    Color FadeColor;
    public Image DelayerFade;
    // Start is called before the first frame update
    void Start()
    {
        FadeColor = DelayerFade.color;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (t > 0)
        {
            
            DelayerFade.color = new Color(FadeColor.r,FadeColor.g,FadeColor.b, t);
            t -= 2*Time.deltaTime;
        }
        else
        {
            DelayerFade.gameObject.SetActive(false);
        }

    }
    public void FadeIn()
    {
        t = 1f;
        DelayerFade.color = new Color(FadeColor.r, FadeColor.g, FadeColor.b, t);
        DelayerFade.gameObject.SetActive(true);
    }
}
