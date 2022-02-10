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

        if (CurrentLevel >= LevelsValues.Length)
        {
            UpgradeChanges.text = "MAX LV.";
        }
        else
        {
            UpgradeChanges.text = (CurrentLevel > 0 ? LevelsValues[CurrentLevel - 1].ToString() : UpgradableBuilding.warriorsLimit.ToString()) + " -> " + LevelsValues[CurrentLevel].ToString();
        }
    }
}
