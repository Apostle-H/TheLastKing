using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountStats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI AllApples;
    [SerializeField] private TextMeshProUGUI AllSidr;
    [SerializeField] private TextMeshProUGUI AllCivilians;
    [SerializeField] private TextMeshProUGUI AllWarrios;
    [SerializeField] private TextMeshProUGUI ConsumedSidr;
    [SerializeField] private TextMeshProUGUI FallenCivilians;
    [SerializeField] private TextMeshProUGUI FallenWarriors;
    [SerializeField] private TextMeshProUGUI OvercomeWavesCount;
    [SerializeField] private TextMeshProUGUI OvercomeEnemiesCount;

    public void PrintStats(int allApples, int allSidr, int allCivilians, int allWarriors, int consumedSidr, int fallenCivilians, int fallenWarriors, int overcomeWavesCount, int overcomeEnemiesCount)
    {
        AllApples.text = allApples.ToString();
        AllSidr.text = allSidr.ToString();
        AllCivilians.text = allCivilians.ToString();
        AllWarrios.text = allWarriors.ToString();
        ConsumedSidr.text = consumedSidr.ToString();
        FallenCivilians.text = fallenCivilians.ToString();
        FallenWarriors.text = fallenWarriors.ToString();
        OvercomeWavesCount.text = overcomeWavesCount.ToString();
        OvercomeEnemiesCount.text = overcomeEnemiesCount.ToString();
    }
}
