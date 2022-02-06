using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garden : ResourceProducer
{
    [Header("Gardens specials")]
    [SerializeField] bool Auto;

    protected override void Start()
    {
        base.Start();

        ProducableAmount = HQ.civilians;

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

    public void UpdateCiviliansAmount(int civiliansAmount)
    {
        ProducableAmount = civiliansAmount;
    }
}
