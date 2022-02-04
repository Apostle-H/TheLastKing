using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garden : ResourceProducer
{
    [SerializeField] bool Auto;

    protected override void Start()
    {
        base.Start();

        if (Auto)
        {
            ProduceResource();
        }
    }

    protected override void GetResource()
    {
        base.GetResource();
        ProduceResource();
    }
}
