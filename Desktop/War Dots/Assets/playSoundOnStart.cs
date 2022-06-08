using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playSoundOnStart : MonoBehaviour
{
    public AudioClip clipToPlay;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(clipToPlay, this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
