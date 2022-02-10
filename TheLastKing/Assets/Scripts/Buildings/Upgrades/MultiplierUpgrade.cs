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

        if (CurrentLevel >= LevelsValues.Length)
        {
            UpgradeChanges.text = "MAX LV.";
        }
        else
        {
            UpgradeChanges.text = (CurrentLevel > 0 ? LevelsValues[CurrentLevel - 1].ToString() : UpgradableBuilding.producableAmountMultiplier.ToString()) + " -> " + LevelsValues[CurrentLevel].ToString();
        }
    }
}
