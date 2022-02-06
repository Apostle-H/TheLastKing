using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerLimitsUpgrade : EmptyUpgrade
{
    [SerializeField] private Tower UpgradableBuilding;

    [SerializeField] private int[] LevelsValues;

    public override void Upgrade()
    {
        UpgradableBuilding.ChangeLimit(LevelsValues[CurrentLevel]);
        base.Upgrade();
        CurrentLevel++;

        ThisUpgradeButton.GetComponentInChildren<TextMeshProUGUI>().text = CurrentLevel.ToString() + " " + "LV.";

        if (CurrentLevel >= LevelsValues.Length)
        {
            ThisUpgradeButton.GetComponentInChildren<TextMeshProUGUI>().text = "MAX LV.";
        }
    }
}
