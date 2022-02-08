using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VillageLimitsUpgrade : EmptyUpgrade
{
    [SerializeField] private Village UpgradableBuilding;

    [SerializeField] private CiviliansWarriorsAmount[] LevelsValues;

    [SerializeField] protected TextMeshProUGUI UpgradeChanges;

    protected override void Start()
    {
        base.Start();
        UpgradeChanges.text = CurrentLevel > 0 ? (LevelsValues[CurrentLevel - 1].ToString() + " -> " + LevelsValues[CurrentLevel].ToString()) : (UpgradableBuilding.civilianLimit.ToString() + " -> " + LevelsValues[CurrentLevel].ToString());
        UpgradeChanges.text += "\n" + (CurrentLevel > 0 ? (LevelsValues[CurrentLevel - 1].ToString() + " -> " + LevelsValues[CurrentLevel].ToString()) : (UpgradableBuilding.warriorLimit.ToString() + " -> " + LevelsValues[CurrentLevel].ToString()));
    }

    public override void Upgrade()
    {
        UpgradableBuilding.ChangeLimit(LevelsValues[CurrentLevel].Civilians, LevelsValues[CurrentLevel].Warriors);
        base.Upgrade();
        
        UpgradeChanges.text = CurrentLevel > 0 ? (LevelsValues[CurrentLevel - 1].ToString() + " -> " + LevelsValues[CurrentLevel].ToString()) : (UpgradableBuilding.civilianLimit.ToString() + " -> " + LevelsValues[CurrentLevel].ToString());
        UpgradeChanges.text += "\n" + (CurrentLevel > 0 ? (LevelsValues[CurrentLevel - 1].ToString() + " -> " + LevelsValues[CurrentLevel].ToString()) : (UpgradableBuilding.warriorLimit.ToString() + " -> " + LevelsValues[CurrentLevel].ToString()));
        ThisUpgradeButton.GetComponentInChildren<TextMeshProUGUI>().text = CurrentLevel.ToString() + " " + "LV.";

        if (CurrentLevel >= LevelsValues.Length)
        {
            ThisUpgradeButton.GetComponentInChildren<TextMeshProUGUI>().text = "MAX LV.";
        }
    }
}
