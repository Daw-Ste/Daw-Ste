using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class UnitButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public KeyCode assignedKey;
    public GameObject UnitData;
    public LoadingUnit UnitQueue;
    public Button thisbutton;
    public Transform SoldierPrefab;
    public int[] price;
    int money, minerals, artifacts;
    public GameObject enemybase, friendbase;
    bool enoughresources;
    public void OnPointerEnter(PointerEventData eventData)
    {
        UnitData.SetActive(true);
        //Debug.Log("The cursor entered the selectable UI element.");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        UnitData.SetActive(false);
        
        //Debug.Log("The cursor exited the selectable UI element.");
    }
    public void Recruit()
    {
        if (friendbase!=null && enoughresources == true&&UnitQueue.activepanels<4)//ograniczenie jednostek w kolejce
        {
            /*Vector3 mousepos = Input.mousePosition;
            Vector3 objectpos = Camera.main.ScreenToWorldPoint(mousepos);
            objectpos.z = 0; */
            /* Vector3 objectpos = friendbase.GetComponent<ResourcesScript>().RallyPoint.position;
             Transform newsoldier = Instantiate(SoldierPrefab, objectpos, Quaternion.identity);
             newsoldier.GetComponent<Movement>().enemy_base = enemybase;*/
            friendbase.GetComponent<ResourcesScript>().AddResources(-price[0], -price[1], -price[2]);

            
            UnitQueue.QueueButton[UnitQueue.activepanels].SetActive(true);
            UnitQueue.QueueButton[UnitQueue.activepanels].GetComponent<activateOnMouseOver>().objectToActivate.SetActive(false);
            UnitQueue.SoldierinQueueName[UnitQueue.activepanels].text = SoldierPrefab.GetComponent<Soldier_Stats>().UnitName;
            UnitQueue.SoldierPrefabinQueue[UnitQueue.activepanels] = SoldierPrefab;
            UnitQueue.TimerinQueue[UnitQueue.activepanels] = SoldierPrefab.GetComponent<Soldier_Stats>().spawntime;
            UnitQueue.activepanels++;
            
            Debug.Log("Unit succesfully recruited");
        }else

        {
            Debug.Log("Not enough resources!");
        }
    }
    private void Update()
    {
        if(Input.GetKeyUp(assignedKey))
        {
            Recruit();
        }
        if (friendbase != null)
        {
            money = friendbase.GetComponent<ResourcesScript>().Money;
            minerals = friendbase.GetComponent<ResourcesScript>().Minerals;
            artifacts = friendbase.GetComponent<ResourcesScript>().Artifacts;
            if (price[0] <= money && price[1] <= minerals && price[2] <= artifacts)
            {
                enoughresources = true;
                thisbutton.interactable = true;
            }
            else
            {
                enoughresources = false;
                thisbutton.interactable = false;
            }
        }
    }
}