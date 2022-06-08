using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : MonoBehaviour
{
    public int bonusDmg, bonusArmour;//adds flat dmg and armour to soldiers
    public float bonusMovementSpeedMultiplier;//-1 and lower stops unit entirely unless other speed buffs are applied; 1 adds 100% movement speed etc.
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AddAuraEffect(Soldier_Stats soldier)
    {
        soldier.dmg += bonusDmg;
        soldier.armour += bonusArmour;
        soldier.this_soldier_movement.movespeedMultiplier += bonusMovementSpeedMultiplier;
    }
    public void DisableAuraEffect(Soldier_Stats soldier)
    {
        soldier.dmg -= bonusDmg;
        soldier.armour -= bonusArmour;
        soldier.this_soldier_movement.movespeedMultiplier -= bonusMovementSpeedMultiplier;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AddAuraEffect(collision.GetComponent<Soldier_Stats>());
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        DisableAuraEffect(collision.GetComponent<Soldier_Stats>());
    }
}
