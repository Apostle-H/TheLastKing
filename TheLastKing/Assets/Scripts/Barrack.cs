using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrack : Timer
{
    [SerializeField] private int warriorsAmount;

    private bool hired;

    public int WarriorCost;

    protected override void Update()
    {
        base.Update();

        if (timeCounter >= timeToFill)
        {
            if (!hired)
            {
                HQ.ManipulateResource(HeadQuaters.resourceType.warriors, warriorsAmount, true);
                hired = true;
            }
        }

        if (hired)
        {
            button.interactable = HQ.CheckResourceRequirements(HeadQuaters.resourceType.food, WarriorCost) && !HQ.IsAtLimit(HeadQuaters.resourceType.warriors);
        }
    }

    public void TrainWarrior()
    {
        button.interactable = false;
        timeCounter = 0;

        HQ.ManipulateResource(HeadQuaters.resourceType.food, WarriorCost, false);
        hired = false;
    }
}
