using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MultiplierUpgrade : EmptyUpgrade
{
    [SerializeField] protected ResourceProducer UpgradableBuilding;

    [SerializeField] float[] LevelsValues;

    public override void Upgrade()
    {
        UpgradableBuilding.ChangeMultiplier(LevelsValues[CurrentLevel]);
        base.Upgrade();
        CurrentLevel++;

        ThisUpgradeButton.GetComponentInChildren<TextMeshProUGUI>().text = CurrentLevel.ToString() + " " + "LV.";

        if (CurrentLevel >= LevelsValues.Length)
        {
            ThisUpgradeButton.GetComponentInChildren<TextMeshProUGUI>().text = "MAX LV.";
        }
    }
}
