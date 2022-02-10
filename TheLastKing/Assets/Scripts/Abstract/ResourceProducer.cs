using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class ResourceProducer : Timer
{
    [Header("Resource producement")]
    [SerializeField] protected resourceType Resource;
    [SerializeField] private float ProducableAmountMultiplier = 1;

    [SerializeField] private bool NeedMaterials;
    [SerializeField] private resourceType Material;
    [SerializeField] private int MaterialAmount;

    [SerializeField] private TextMeshProUGUI MaterialResourceText;
    [SerializeField] private TextMeshProUGUI MaterialResourceAmountText;

    protected int ProducableAmount = 1;
    protected bool GotResource = true;

    public float producableAmountMultiplier { get { return ProducableAmountMultiplier; } }

    protected override void Start()
    {
        base.Start();

        if (NeedMaterials)
        {
            MaterialResourceText.text = Material.ToString();
            MaterialResourceAmountText.text = MaterialAmount.ToString();
        }
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
        HQ.ManipulateResource(Resource, Mathf.RoundToInt(ProducableAmount * ProducableAmountMultiplier), true);
        GotResource = true;
    }

    public virtual void ChangeMultiplier(float newMultiplier)
    {
        ProducableAmountMultiplier = newMultiplier;
    }
}
