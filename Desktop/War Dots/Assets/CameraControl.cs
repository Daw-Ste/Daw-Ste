using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float XYSpeed=20, scrollSpeed=1, minProjectionSize, maxProjectionSize;
    public Camera Cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel")*scrollSpeed;
        Cam.orthographicSize= Mathf.Clamp(Cam.orthographicSize, minProjectionSize, maxProjectionSize);
    }
}
