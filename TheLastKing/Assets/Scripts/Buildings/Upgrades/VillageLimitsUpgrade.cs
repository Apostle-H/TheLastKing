using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VillageLimitsUpgrade : EmptyUpgrade
{
    [SerializeField] private Village UpgradableBuilding;

    [SerializeField] private CiviliansWarriorsAmount[] LevelsValues;

    public override void Upgrade()
    {
        UpgradableBuilding.ChangeLimit(LevelsValues[CurrentLevel].Civilians, LevelsValues[CurrentLevel].Warriors);
        base.Upgrade();
        CurrentLevel++;

        ThisUpgradeButton.GetComponentInChildren<TextMeshProUGUI>().text = CurrentLevel.ToString() + " " + "LV.";

        if (CurrentLevel >= LevelsValues.Length)
        {
            ThisUpgradeButton.GetComponentInChildren<TextMeshProUGUI>().text = "MAX LV.";
        }
    }
}
