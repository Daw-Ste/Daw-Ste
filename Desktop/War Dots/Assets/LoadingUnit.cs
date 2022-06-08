using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LoadingUnit : MonoBehaviour
{
    public GameObject[]  QueueButton;
    public Transform[] SoldierPrefabinQueue;
    public GameObject  enemybase, GameManager;
    public ResourcesScript friendbase;
    public float[] TimerinQueue;
    public TMP_Text[] SoldierinQueueName;
    public float t = 0, spawn_multiplier=1, oneTimeSpawnMultiplier=1;
    public Image circle;
    public int activepanels;
    int x = 0;

    void Update()
    {
        if(activepanels>0&&t>=TimerinQueue[0]&&friendbase!=null)
        {
            Vector3 objectpos = friendbase.RallyPoint.position;
            Transform newsoldier = Instantiate(SoldierPrefabinQueue[0], objectpos, Quaternion.identity);
            newsoldier.GetComponent<Movement>().enemy_base = enemybase;
            newsoldier.GetComponent<Soldier_Stats>().GameManager = GameManager;
            if(newsoldier.GetComponent<changeSpawntimeOfNextSoldier>()!=null)
            {
                newsoldier.GetComponent<changeSpawntimeOfNextSoldier>().unitQueue = this;

            }

            t = 0;
            activepanels--;
            QueueButton[activepanels].SetActive(false);
            if(activepanels>0)
            {
                
                while(x<=2)
                {
                    SoldierPrefabinQueue[x] = SoldierPrefabinQueue[x+1];
                    TimerinQueue[x ] = TimerinQueue[x+1];
                    SoldierinQueueName[x ].text = SoldierinQueueName[x+1].text;
                    x++;
                }
                x = 0;

            }
            oneTimeSpawnMultiplier = 1;
        }
     else if(activepanels>0)
        {
            t += Time.deltaTime*spawn_multiplier*oneTimeSpawnMultiplier;
            circle.fillAmount = 1-t/TimerinQueue[0];
        }
    }
    public void CancelUnitLoad(int placeInQueue)
    {
        if (placeInQueue == 0)
        {
            t = 0;
        }
        Soldier_Stats soldierPrefab=SoldierPrefabinQueue[placeInQueue].GetComponent<Soldier_Stats>();
        friendbase.AddResources(soldierPrefab.moneyCost,soldierPrefab.mineralCost,soldierPrefab.artifactCost);
        activepanels--;
        QueueButton[activepanels].SetActive(false);
        if (activepanels > 0)
        {
            x = placeInQueue;
            while (x <= 2)
            {
                SoldierPrefabinQueue[x] = SoldierPrefabinQueue[x + 1];
                TimerinQueue[x] = TimerinQueue[x + 1];
                SoldierinQueueName[x].text = SoldierinQueueName[x + 1].text;
                x++;
            }
            x = 0;
        }
    }
}
