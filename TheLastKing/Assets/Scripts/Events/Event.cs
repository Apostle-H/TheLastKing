using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Event : MonoBehaviour
{
    private HeadQuaters HQ;

    [SerializeField] private ResourceAndValue[] ResourcesAndMultipliers;
    [SerializeField] private ResourceAndValue[] ResourcesAndPenaltys;

    [SerializeField] private TextMeshProUGUI EventText;

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
            EventText.text += $"lost {Mathf.RoundToInt(HQ.GetResourceValue(ResourcesAndPenaltys[i].resource) * ResourcesAndPenaltys[i].value)} {ResourcesAndPenaltys[i].resource}\n";
        }

        for (int i = 0; i < ResourcesAndMultipliers.Length; i++)
        {
            HQ.MultiplyResourceEventMultiplier(ResourcesAndMultipliers[i].resource, ResourcesAndMultipliers[i].value);
            EventText.text += $"{ResourcesAndPenaltys[i].resource} produce efficiency is lowered by {ResourcesAndPenaltys[i].value * 100}%\n";
        }
    }

    public void EventEnd()
    {
        for (int i = 0; i < ResourcesAndMultipliers.Length; i++)
        {
            HQ.MultiplyResourceEventMultiplier(ResourcesAndMultipliers[i].resource, (Mathf.Pow(ResourcesAndMultipliers[i].value, -1f)));
        }

        Destroy(gameObject);
    }
}
