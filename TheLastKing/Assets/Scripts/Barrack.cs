using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrack : Timer
{
    [SerializeField] private int warriorsAmount;

    private bool hired;

    public static int WarriorCost = 2;

    protected override void Update()
    {
        base.Update();

        if (timeCounter >= time)
        {
            if (!hired)
            {
                HQ.HireWarrior(warriorsAmount);
                hired = true;
            }
        }

        if (hired)
        {
            button.interactable = HQ.CanTrainWarrior();
        }
    }

    public void TrainWarrior()
    {
        button.interactable = false;
        timeCounter = 0;

        HQ.PaySomeFood(WarriorCost);
        hired = false;
    }
}
