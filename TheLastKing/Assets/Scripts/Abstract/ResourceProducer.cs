using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ResourceProducer : Timer
{
    [SerializeField] private resourceType Resource;
    [SerializeField] private int ProducableAmount;

    [SerializeField] private bool NeedMaterials;
    [SerializeField] private resourceType Material;
    [SerializeField] private int MaterialAmount;    

    protected bool GotResource = true;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        if (!GotResource)
        {
            base.Update();
        }

        if (TimeCounter >= TimeToFill && !GotResource)
        {
            GetResource();
        }

        if (GotResource)
        {
            ActionButton.interactable = HQ.CheckResourceRequirements(Material, MaterialAmount);
        }
    }

    public virtual void ProduceResource()
    {
        HQ.ManipulateResource(Material, MaterialAmount, false);
        TimeCounter = 0;
        GotResource = false;

        ActionButton.interactable = false;
    }

    protected virtual void GetResource()
    {
        HQ.ManipulateResource(Resource, ProducableAmount, true);
        GotResource = true;
    }

}
