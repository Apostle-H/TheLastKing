using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woods : Timer
{
    [SerializeField] private int peasentsAmount;
    
    private bool hired;

    public static int PeasentCost = 1;

    protected override void Update()
    {
        base.Update();

        if (timeCounter >= time)
        {
            if (!hired)
            {
                HQ.HirePeasent(peasentsAmount);
                hired = true;
            }
        }

        if (hired)
        {
            button.interactable = HQ.CanGetPeasent();
        }
    }

    public void FindPeasent()
    {
        button.interactable = false;
        timeCounter = 0;

        HQ.PaySomeFood(PeasentCost);
        hired = false;
    }
}
