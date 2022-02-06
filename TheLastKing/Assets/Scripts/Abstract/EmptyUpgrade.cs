using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class EmptyUpgrade : MonoBehaviour
{
    [SerializeField] protected HeadQuaters HQ;
    [SerializeField] protected Button ThisUpgradeButton;

    [SerializeField] protected resourceType UpgradeMaterial;
    [SerializeField] protected int[] UpgradeLevelsMaterialAmount;

    protected int CurrentLevel = 0;

    protected void Update()
    {
        ThisUpgradeButton.interactable = CheckUpgradeRequirements();
    }

    protected virtual bool CheckUpgradeRequirements()
    {
        return CurrentLevel < UpgradeLevelsMaterialAmount.Length && HQ.CheckResourceAmount(UpgradeMaterial, UpgradeLevelsMaterialAmount[CurrentLevel]);
    }

    public virtual void Upgrade()
    {
        HQ.ManipulateResource(UpgradeMaterial, UpgradeLevelsMaterialAmount[CurrentLevel], false);
    }
}
