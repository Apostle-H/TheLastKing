using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MultiplierUpgrade : EmptyUpgrade
{
    [SerializeField] protected ResourceProducer UpgradableBuilding;

    [SerializeField] float[] LevelsValues;

    [SerializeField] protected TextMeshProUGUI UpgradeChanges;

    protected override void Start()
    {
        base.Start();
        UpgradeChanges.text = (CurrentLevel > 0 ? LevelsValues[CurrentLevel - 1].ToString() : UpgradableBuilding.producableAmountMultiplier.ToString()) + " -> " + LevelsValues[CurrentLevel].ToString();
    }

    public override void Upgrade()
    {
        UpgradableBuilding.ChangeMultiplier(LevelsValues[CurrentLevel]);
        base.Upgrade();

        UpgradeChanges.text = (CurrentLevel > 0 ? LevelsValues[CurrentLevel - 1].ToString() : UpgradableBuilding.producableAmountMultiplier.ToString()) + " -> " + LevelsValues[CurrentLevel].ToString();

        if (CurrentLevel >= LevelsValues.Length)
        {
            ThisUpgradeButton.GetComponentInChildren<TextMeshProUGUI>().text = "MAX LV.";
        }
    }
}
