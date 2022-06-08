using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class artilleryMarkerScript : MonoBehaviour
{
    public float timetoDie;
    public GameObject blueSmoke, redSmoke, blueExplosion, redExplosion;
    float timeLeft;
    [SerializeField]
    SpriteRenderer thisSprite;
     public bool isPlayersMissile;
    public int dmg;
    Color spriteColor;
    // Start is called before the first frame update

    void Start()
    {
        timeLeft = timetoDie;
        spriteColor.a = 0;
        thisSprite.color = spriteColor;
        if (isPlayersMissile)
        { thisSprite.color = new Color(1f, 1f, 1f, 0) * Color.cyan; }
        else { thisSprite.color = new Color(1f, 1f, 1f, 0) * Color.red; }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(timeLeft>0)
        {
            if (isPlayersMissile)
            { thisSprite.color = new Color(1f, 1f, 1f, 0.5f * (1 - timeLeft / timetoDie)) * Color.cyan; }
            else { thisSprite.color = new Color(1f, 1f, 1f, 0.5f * (1 - timeLeft / timetoDie)) * Color.red; }
            timeLeft -= Time.deltaTime;
        }
        else
        {
            if (isPlayersMissile)
            { 
                GameObject hitEffect = Instantiate(blueSmoke, this.transform.position, Quaternion.identity);
                GameObject explosionclone = Instantiate(blueExplosion, this.transform.position, Quaternion.identity);
                explosionclone.GetComponent<Missile_Script>().dmg = dmg;
            }
            else 
            { 
                GameObject hitEffect = Instantiate(redSmoke, this.transform.position, Quaternion.identity);
                GameObject explosionclone = Instantiate(redExplosion, this.transform.position, Quaternion.identity);
                explosionclone.GetComponent<Missile_Script>().dmg = dmg;
            }           
            Destroy(this.gameObject);
        }
    }
}
