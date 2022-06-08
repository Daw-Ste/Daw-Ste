using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ResourcesScript : MonoBehaviour
{
    public int Money, Minerals, Artifacts;
    public Transform RallyPoint;
    public TMP_Text moneytext, mineraltext, artifacttext;
    float t, timetoresources = 1;
    public int[] resourcespersecond;
    // Start is called before the first frame update

    private void Start()
    {
        AddResources(0, 0, 0);
    }
    private void Update()
    {
        if (t >= timetoresources)
        {
            AddResources(resourcespersecond[0], resourcespersecond[1], resourcespersecond[2]);
            t = 0;
        }
        else
            t += Time.deltaTime ;
        
    }
    public void AddResources(int resource_money, int resource_mineral, int resource_artifact)
    {
        Money += resource_money;
        moneytext.text = Money.ToString();

        Minerals += resource_mineral;
        mineraltext.text = Minerals.ToString();

        Artifacts += resource_artifact;
        artifacttext.text = Artifacts.ToString();
    }
}
