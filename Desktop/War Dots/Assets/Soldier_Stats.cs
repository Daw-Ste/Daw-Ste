using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier_Stats : MonoBehaviour
{
    public string UnitName;
    public int unitID;// 100=Base, 101=Turret, 102=Barracks, units 0-swordsman, 1-archer, 2-spearman, 3-axe thrower, 4-knight, 5-horse archer, 6-pirate, 7-mortar
    [SerializeField]
    private ParticleSystem MoneySplash;
    public int maxhp, hp, basedmg, dmg, armour, moneyreward, mineralreward, artifactreward, moneyCost, mineralCost, artifactCost, target_priority;//target_priority: 4-high priority units 3-units 2-buildings 1-base
    public float spawntime=1, size;
    public GameObject detector, soldier, GameManager, colliderstodestroyondeath, horse_archer_horse;
    public Transform unRotator;
    [SerializeField]
    private Animator unit_animator;
    public Movement this_soldier_movement;
    float dyingtimer=1;
    Color soldier_colour;
    public bool alive = true,double_bounty, building, mainBuilding, horse_archer;

    void Update()
    {
        if (!alive && dyingtimer > 0)
        {
            dyingtimer -= Time.deltaTime;
            soldier.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,dyingtimer);
            if(horse_archer==true)
            {
                horse_archer_horse.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, dyingtimer);
            }
            soldier.transform.Rotate(720 * dyingtimer * Time.deltaTime, 0, 0);
        }else
        if (!alive && dyingtimer <= 0)
        {
            
            if (mainBuilding==true&& this.gameObject.CompareTag("Green"))
            {
                GameFInish finisher = GameManager.GetComponent<GameFInish>();
                finisher.defeat_true=true;
                finisher.defeattext.gameObject.SetActive(true);
                finisher.EndTime = (int)Time.timeSinceLevelLoad;
            }else if(mainBuilding==true)
            {
                GameFInish finisher = GameManager.GetComponent<GameFInish>();
                finisher.victory_true=true;
                finisher.victorytext.gameObject.SetActive(true);
                finisher.EndTime = (int)Time.timeSinceLevelLoad;
            }
            Destroy(soldier);
            
        }
    }
    public void KilledAnEnemy(Soldier_Stats killed_unit)
    {

    }
    public void DamagedAUnit()
    {

    }
    public void TakeDamage(int damageTaken, Soldier_Stats attacker)
    {
        if (damageTaken > armour)
        {
            hp -= damageTaken - armour;

            if (unRotator != null)////////////usunać jak wszystkie jednostki beda mialy wrzucony hp bar
            {
                unRotator.GetComponent<healthbarScript>().healthbarUpdate(hp,maxhp);
               /* healthbar.gameObject.SetActive(true);
                if(hp*1f/maxhp>0.5f)
                {
                    actualHealthbar.color = new Color((maxhp-hp)*2f/maxhp,1f,0f, 1f);
                }else if(hp * 1f / maxhp <= 0.5f)
                {
                    actualHealthbar.color = new Color(1f, hp*2f/maxhp, 0f, 1f);
                }
                healthpivot.localScale = new Vector3(hp * 1f / maxhp , 1, 1); 
               */
            }
        }
        if (hp <= 0 && alive == true && building == false)
        {
            Die();
            //attacker.KilledAnEnemy(this);
            detector.SetActive(false);
            this_soldier_movement.enabled = false;
            soldier.GetComponent<CircleCollider2D>().enabled = false;
            if (this.gameObject.CompareTag("Red"))
            {
                ParticleSystem moneyeffect = Instantiate(MoneySplash, transform.position, Quaternion.identity);
                moneyeffect.transform.eulerAngles = new Vector3(-90, 0, 0);
                if (this_soldier_movement.enemy_base != null)
                {
                    this_soldier_movement.enemy_base.GetComponent<ResourcesScript>().AddResources(moneyreward, mineralreward, artifactreward);
                    if(attacker!=null)
                    {
                        if (attacker.double_bounty)
                            this_soldier_movement.enemy_base.GetComponent<ResourcesScript>().AddResources(moneyreward, mineralreward, artifactreward);
                    }
                    
                }
            }

        }
        else if (hp <= 0 && alive==true && building == true)
        {
            Die();
            soldier.GetComponent<BoxCollider2D>().enabled = false;

        }
    }
    void Die()
    {
        alive = false;
        if (unRotator != null)////////////usunać jak wszystkie jednostki beda mialy wrzucony hp bar
            unRotator.gameObject.SetActive(false);
        if (colliderstodestroyondeath != null)
            colliderstodestroyondeath.SetActive(false);
        if (unit_animator != null)
            unit_animator.enabled = false;
        if (this.gameObject.CompareTag("Red"))
        {
            if(!building)
            GameManager.GetComponent<GameFInish>().DefeatedEnemies++;
        }else
        {
            if(!building)
            GameManager.GetComponent<GameFInish>().LostUnits++;
        }
    }    
}
