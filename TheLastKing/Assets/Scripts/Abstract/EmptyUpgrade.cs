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

    [SerializeField] protected GameObject ZeroLevelTilemap;
    [SerializeField] protected GameObject[] UpgradeLevelTilemaps;

    protected int CurrentLevel = 0;

    protected virtual void Start()
    {
        UpgradeCostGUI.text = UpgradeLevelsMaterialAmount[CurrentLevel].ToString() + " " + UpgradeMaterial.ToString();
        ThisUpgradeButton.GetComponentInChildren<TextMeshProUGUI>().text = CurrentLevel.ToString() + " " + "LV.";
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
        if (CurrentLevel < UpgradeLevelTilemaps.Length)
        {
            if (CurrentLevel == 0)
            {
                ZeroLevelTilemap.SetActive(false);
            }
            else
            {
                UpgradeLevelTilemaps[CurrentLevel - 1].SetActive(false);
            }

            UpgradeLevelTilemaps[CurrentLevel].SetActive(true);
        }
        CurrentLevel++;

        if (CurrentLevel >= UpgradeLevelsMaterialAmount.Length)
        {
            ThisUpgradeButton.GetComponentInChildren<TextMeshProUGUI>().text = "MAX LV.";
            UpgradeCostGUI.text = "MAX LV.";
        }
        else
        {
            UpgradeCostGUI.text = UpgradeLevelsMaterialAmount[CurrentLevel].ToString() + " " + UpgradeMaterial.ToString();
            ThisUpgradeButton.GetComponentInChildren<TextMeshProUGUI>().text = CurrentLevel.ToString() + " " + "LV.";
        }
    }
}
