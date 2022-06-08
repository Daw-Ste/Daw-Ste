using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDetector : MonoBehaviour
{

    void Update()
    {
        Detect(this.transform.position, 30000);
    }
    void Detect(Vector3 center, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            float distance = (this.transform.position - hitCollider.transform.position).magnitude;
            Debug.Log("Enemy is" + distance + "units away");
        }
    }
}
