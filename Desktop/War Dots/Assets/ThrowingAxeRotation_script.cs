using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingAxeRotation_script : MonoBehaviour
{
    public float center_rotation_speed, axe_rotation_speed;
    public Transform axe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0, 0, center_rotation_speed * Time.deltaTime);
        axe.transform.Rotate(0, 0, -axe_rotation_speed * Time.deltaTime);
    }
}
