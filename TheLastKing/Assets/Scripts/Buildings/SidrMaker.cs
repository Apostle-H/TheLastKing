using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidrMaker : ResourceProducer
{
    [Header("Sidr specials")]
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

        if (Auto)
        {
            ProduceResource();
        }
    }

    public void SetAuto()
    {
        Auto = !Auto;
    }
}
