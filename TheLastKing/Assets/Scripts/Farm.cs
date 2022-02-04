using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : Timer
{
    [SerializeField] bool autoGather;

    [SerializeField] private List<int> foodIncome = new List<int>();

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        if (timeCounter >= timeToFill)
        {
            if (autoGather)
            {
                GatherFood();
            }
            else
            {
                button.interactable = true;
            }
        }
    }

    public void GatherFood()
    {
        button.interactable = false;
        timeCounter = 0;

        HQ.ManipulateResource(HeadQuaters.resourceType.food, foodIncome.ElementsSum(), true);
    }
}
