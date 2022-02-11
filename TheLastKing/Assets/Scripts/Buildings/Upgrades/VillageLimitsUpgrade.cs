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
        UpgradeChanges.text = (CurrentLevel > 0 ? LevelsValues[CurrentLevel - 1].ToString() : UpgradableBuilding.civilianLimit.ToString()) + " -> " + LevelsValues[CurrentLevel].Civilians.ToString();
        UpgradeChanges.text += "\n" + (CurrentLevel > 0 ? LevelsValues[CurrentLevel - 1].ToString() : UpgradableBuilding.warriorLimit.ToString()) + " -> " + LevelsValues[CurrentLevel].Warriors.ToString();
    }

    public override void Upgrade()
    {
        UpgradableBuilding.ChangeLimit(LevelsValues[CurrentLevel].Civilians, LevelsValues[CurrentLevel].Warriors);
        base.Upgrade();
        
        if (CurrentLevel >= LevelsValues.Length)
        {
            UpgradeChanges.text = "MAX LV.";
        }
        else
        {
            UpgradeChanges.text = (CurrentLevel > 0 ? LevelsValues[CurrentLevel - 1].Civilians.ToString() : UpgradableBuilding.civilianLimit.ToString()) + " -> " + LevelsValues[CurrentLevel].Civilians.ToString();
            UpgradeChanges.text += "\n" + (CurrentLevel > 0 ? LevelsValues[CurrentLevel - 1].Warriors.ToString() : UpgradableBuilding.warriorLimit.ToString()) + " -> " + LevelsValues[CurrentLevel].Warriors.ToString();
        }
    }
}
