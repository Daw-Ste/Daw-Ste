using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amBush : MonoBehaviour
{
    bool shaking = false;
    int shake_phase = 1;
    float timelefttoshake;
    public float shakingtime;
    public GameObject GameManager, playerBase;
    public Transform soldierToSpawn;
    public ParticleSystem leafParticle;
    public AudioClip leafSound;
    Vector3 starting_position;
    // Start is called before the first frame update
    void Start()
    {
        starting_position = this.transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (shaking == false)
        {
            shaking = true;
            timelefttoshake = shakingtime;
        }
        if (shaking == true && timelefttoshake > 0)
        {
            switch (shake_phase)
            {
                case 1:
                    this.transform.position = starting_position + new Vector3(timelefttoshake, timelefttoshake, 0);
                    shake_phase = 2;
                    break;
                case 2:
                    this.transform.position = starting_position - new Vector3(timelefttoshake, timelefttoshake, 0);
                    shake_phase = 3;
                    break;
                case 3:
                    this.transform.position = starting_position + new Vector3(-timelefttoshake, timelefttoshake, 0);
                    shake_phase = 4;
                    break;
                case 4:
                    this.transform.position = starting_position + new Vector3(timelefttoshake, -timelefttoshake, 0);
                    shake_phase = 1;
                    break;
                default:
                    break;
            }
            if (timelefttoshake > -2)
                timelefttoshake -= Time.deltaTime;
            if (timelefttoshake > -2 && timelefttoshake <= 0)
                this.transform.position = starting_position;

        }
        else if (timelefttoshake <= 0)
        {
            soldierAmbush();
        }
    }
    void soldierAmbush()
    {
        ParticleSystem leafClone = Instantiate(leafParticle, starting_position, Quaternion.identity);

        Transform soldierclone = Instantiate(soldierToSpawn, this.transform.position, Quaternion.identity);
        soldierclone.GetComponent<Movement>().enemy_base = playerBase;
            soldierclone.GetComponent<Soldier_Stats>().GameManager = GameManager;

        AudioSource.PlayClipAtPoint(leafSound, (this.transform.position));
        shaking = false;
        this.enabled = false;
    }
}
