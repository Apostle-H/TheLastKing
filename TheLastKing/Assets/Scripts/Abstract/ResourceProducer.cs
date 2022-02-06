using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ResourceProducer : Timer
{
    [Header("Resource producement")]
    [SerializeField] protected resourceType Resource;
    [SerializeField] protected int ProducableAmount;

    [SerializeField] private bool NeedMaterials;
    [SerializeField] private resourceType Material;
    [SerializeField] private int MaterialAmount;

    private float ProducableAmountMultiplier = 1;
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
            ActionButton.interactable = CheckWorkRequirements();
        }
    }

    protected virtual bool CheckWorkRequirements()
    {
        return HQ.CheckResourceAmount(Material, MaterialAmount);
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
        HQ.ManipulateResource(Resource, (int)Mathf.Round(ProducableAmount * ProducableAmountMultiplier), true);
        GotResource = true;
    }

    public virtual void ChangeMultiplier(float newMultiplier)
    {
        ProducableAmountMultiplier = newMultiplier;
    }
}
