using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAura : MonoBehaviour
{
    public FollowObject auraPrefab;

    private void Awake()
    {
        FollowObject auraclone = Instantiate(auraPrefab, this.transform.position, Quaternion.identity);
        auraclone.Followed = this.transform;
    }
}
