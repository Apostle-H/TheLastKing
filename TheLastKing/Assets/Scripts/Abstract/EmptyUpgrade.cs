using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class EmptyUpgrade : MonoBehaviour
{
    [SerializeField] protected HeadQuaters HQ;

    [SerializeField] protected resourceType UpgradeMaterial;
    [SerializeField] protected int[] UpgradeLevelsMaterialAmount;

    [SerializeField] protected Button ThisUpgradeButton;
    [SerializeField] protected TextMeshProUGUI UpgradeCostGUI;

    protected int CurrentLevel = 0;

    protected virtual void Start()
    {
        UpgradeCostGUI.text = UpgradeLevelsMaterialAmount[CurrentLevel].ToString() + " " + UpgradeMaterial.ToString();
    }

    protected virtual void Update()
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
        CurrentLevel++;

        UpgradeCostGUI.text = UpgradeLevelsMaterialAmount[CurrentLevel].ToString() + " " + UpgradeMaterial.ToString();
    }
}
