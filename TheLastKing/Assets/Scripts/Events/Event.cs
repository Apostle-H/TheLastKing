using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    private HeadQuaters HQ;

    [SerializeField] private BuildingAndValue[] BuildingsAndMultipliers;
    [SerializeField] private ResourceAndValue[] ResourcesAndPenaltys;

    private void Start()
    {
        HQ = GameObject.FindGameObjectWithTag("GameController").GetComponent<HeadQuaters>();

        Pause.isPaused = true;
        EventStart();
    }

    public void EventStart()
    {
        for (int i = 0; i < ResourcesAndPenaltys.Length; i++)
        {
            HQ.ManipulateResource(ResourcesAndPenaltys[i].resource, Mathf.RoundToInt(HQ.GetResourceValue(ResourcesAndPenaltys[i].resource) * ResourcesAndPenaltys[i].value), false);
        }

        for (int i = 0; i < BuildingsAndMultipliers.Length; i++)
        {
            BuildingsAndMultipliers[i].building.MultiplyMultiplier(BuildingsAndMultipliers[i].value);
        }
    }

    public void EventEnd()
    {
        for (int i = 0; i < BuildingsAndMultipliers.Length; i++)
        {
            BuildingsAndMultipliers[i].building.MultiplyMultiplier(Mathf.Pow(BuildingsAndMultipliers[i].value, -1f), false);
        }

        Destroy(gameObject);
    }
}
