using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBasedSpriteSwap : MonoBehaviour
{
    public Soldier_Stats building;
    public Sprite[] sprite;
    public int numberofsprites;
    int maxhp;
    // Start is called before the first frame update
    void Start()
    {
        maxhp = building.maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        int hp_phase = (100*building.hp / maxhp ) / (100/numberofsprites);
        if (hp_phase < numberofsprites-1&& hp_phase>=0)
        SwapSprite(hp_phase);
    }
    void SwapSprite(int phase)
    {
        building.GetComponent<SpriteRenderer>().sprite = sprite[phase];
    }
}
