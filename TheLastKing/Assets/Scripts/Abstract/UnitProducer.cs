using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitProducer : ResourceProducer
{
    protected override bool CheckWorkRequirements()
    {
        return base.CheckWorkRequirements() && !HQ.IsAtLimit(Resource);
    }
}
