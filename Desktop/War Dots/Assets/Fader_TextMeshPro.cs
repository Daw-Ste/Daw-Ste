using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fader_TextMeshPro : MonoBehaviour
{
    public float timeToStartFadingOut, timetoFadeOut;
    public TMP_Text text;
    float t = 0;
    int phase = 1;
    // Start is called before the first frame update


    // Update is called once per frame
    private void FixedUpdate()
    {
        switch (phase)
        {
            case 1:
                if (t < timeToStartFadingOut)
                {
                    t += Time.deltaTime;
                }
                else if (t >= timeToStartFadingOut)
                {
                    t = 0;
                    phase++;
                }
                break;
            case 2:
                if (t < timetoFadeOut)
                {
                    t += Time.deltaTime;
                    text.color = new Color(text.color.r,text.color.g,text.color.b,1-t/timetoFadeOut);
                }
                else if (t >= timetoFadeOut)
                {
                    this.gameObject.SetActive(false);
                }
                break;
        }
        
    }
}
