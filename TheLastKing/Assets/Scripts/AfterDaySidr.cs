using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterDaySidr : Timer
{
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
            TimeCounter = 0;
        }
    }
}
