using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerLimitsUpgrade : EmptyUpgrade
{
    [SerializeField] private Tower UpgradableBuilding;

    [SerializeField] private int[] LevelsValues;

    [SerializeField] protected TextMeshProUGUI UpgradeChanges;

    protected override void Start()
    {
        base.Start();
        UpgradeChanges.text = (CurrentLevel > 0 ? LevelsValues[CurrentLevel - 1].ToString() : UpgradableBuilding.warriorsLimit.ToString()) + " -> " + LevelsValues[CurrentLevel].ToString();
    }

    public override void Upgrade()
    {
        UpgradableBuilding.ChangeLimit(LevelsValues[CurrentLevel]);
        base.Upgrade();

        UpgradeChanges.text = (CurrentLevel > 0 ? LevelsValues[CurrentLevel - 1].ToString() : UpgradableBuilding.warriorsLimit.ToString()) + " -> " + LevelsValues[CurrentLevel].ToString();
        ThisUpgradeButton.GetComponentInChildren<TextMeshProUGUI>().text = CurrentLevel.ToString() + " " + "LV.";

        if (CurrentLevel >= LevelsValues.Length)
        {
            ThisUpgradeButton.GetComponentInChildren<TextMeshProUGUI>().text = "MAX LV.";
        }
    }
}
