using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_shake : MonoBehaviour
{
    bool shaking=false;
    int shake_phase=1;
    float timelefttoshake;
    public float shakingtime;
    Vector3 starting_position;
    // Start is called before the first frame update
    void Start()
    {
        
        starting_position = this.transform.position;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("space") && shaking == false)
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
            if(timelefttoshake>-2)
            timelefttoshake -= Time.deltaTime;
            if (timelefttoshake > -2 && timelefttoshake <= 0)
                this.transform.position = starting_position;

        }
        else if (timelefttoshake <= 0)
        {

                shaking = false;
           // this.transform.position = starting_position;
        }
    }
}
