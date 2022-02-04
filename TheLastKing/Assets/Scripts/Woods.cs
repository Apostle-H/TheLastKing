using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woods : Timer
{
    [SerializeField] private int civilianAmount;
    
    private bool hired;

    public int CivilianCost;

    protected override void Update()
    {
        base.Update();

        if (timeCounter >= timeToFill)
        {
            if (!hired)
            {
                HQ.ManipulateResource(HeadQuaters.resourceType.civilians, civilianAmount, true);
                hired = true;
            }
        }

        if (hired)
        {
            button.interactable = HQ.CheckResourceRequirements(HeadQuaters.resourceType.food, CivilianCost) && !HQ.IsAtLimit(HeadQuaters.resourceType.civilians);
        }
    }

    public void FindPeasent()
    {
        button.interactable = false;
        timeCounter = 0;

        HQ.ManipulateResource(HeadQuaters.resourceType.food, CivilianCost, false);
        hired = false;
    }
}
