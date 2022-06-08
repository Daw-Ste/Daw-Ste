using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    //This script is to allow objects to follow other objects, not be affected by parent scale and rotation changes and also not get destroyed when parent is destroyed
    public Transform Followed;
    public bool destroyedWithParent;
    private void LateUpdate()
    {
        if (Followed != null)
            this.transform.position = Followed.position;
        if(destroyedWithParent&&Followed==null)
        {
            Destroy(this.gameObject);
        }
    }
}
