using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterDay : Timer
{
    [SerializeField] private Event[] Events;

    private Event CurrentEvent;

    protected override void Start()
    {
        TimeCounter = 0;
    }

    protected override void Update()
    {
        base.Update();

        if (TimeCounter >= TimeToFill)
        {
            HQ.DrinkSidr();

            if (CurrentEvent != null)
            {
                CurrentEvent.EventEnd();
            }
            if (Events.Length > 0)
            {
                CurrentEvent = Events[Random.Range(0, Events.Length)];
                CurrentEvent = Instantiate(CurrentEvent.gameObject, HQ.transform).GetComponent<Event>();
            }
            
            TimeCounter = 0;
        }
    }
}
