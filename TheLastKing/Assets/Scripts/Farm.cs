using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : Timer
{
    [SerializeField] bool autoGather;

    private List<int> foodIncome = new List<int>();

    protected override void Start()
    {
        base.Start();

        foodIncome.Add(5);
    }

    protected override void Update()
    {
        base.Update();

        if (timeCounter >= time)
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

        HQ.StoreFood(foodIncome.ElementsSum());
    }
}
