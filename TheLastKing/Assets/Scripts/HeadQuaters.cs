using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeadQuaters : MonoBehaviour
{
    [Header("Resources")] 
    [SerializeField] private int Apples;
    [SerializeField] private int Sidr;

    [SerializeField] private int Civilians;
    [SerializeField] private int Warriors;

    [Header("Resuorces GUI")]
    [SerializeField] private TextMeshProUGUI ApplesGUI;
    [SerializeField] private TextMeshProUGUI SidrGUI;

    [SerializeField] private TextMeshProUGUI CiviliansGUI;
    [SerializeField] private TextMeshProUGUI WarriorsGUI;

    [Header("Resuorces event multiplier GUI")]
    [SerializeField] private TextMeshProUGUI ApplesEventMultiplierGUI;
    [SerializeField] private TextMeshProUGUI SidrEventMultiplierGUI;

    [SerializeField] private TextMeshProUGUI CiviliansEventMultiplierGUI;
    [SerializeField] private TextMeshProUGUI WarriorsEventMultiplierGUI;

    [Header("Buildings")]
    [SerializeField] Garden Garden;
    [SerializeField] Tower Tower; 
    [SerializeField] private Village Village;

    [Header("Win/Lose panels")] 
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject LosePanel;

    [SerializeField] private GameObject PauseButton;

    private float applesEventMultiplier = 1;
    private float sidrEventMultiplier = 1;
    private float civiliansEventMultiplier = 1;
    private float warriorsEventMultiplier = 1;

    // Properties
    public int apples { get { return Apples; } }
    public int sidr { get { return Sidr; } }
    public int civilians { get { return Civilians; } }
    public int warriors { get { return Warriors; } }

    private int AllApples;
    private int AllSidr;
    private int AllCivilians = 1;
    private int AllWarrios;
    private int ConsumedSidr;
    private int FallenCivilians;
    private int FallenWarriors;
    private int OvercomeWavesCount;
    private int OvercomeEnemiesCount;

    private void Start()
    {
        Pause.isPaused = false;
        WriteResourceValues(resourceType.apples);
        WriteResourceValues(resourceType.sidr);
        WriteResourceValues(resourceType.civilians);
        WriteResourceValues(resourceType.warriors);
    }

    /// <summary>
    /// Change any "resource" value by "amout"
    /// </summary>
    /// <param name="resource"></param>
    /// <param name="amount"></param>
    /// <param name="getOrLose"></param>
    public void ManipulateResource(resourceType resource, int amount, bool getOrLose)
    {
        switch (resource)
        {
            case resourceType.apples:
                Apples += Mathf.RoundToInt((getOrLose ? amount : -amount) * applesEventMultiplier);
                WriteResourceValues(resourceType.apples);
                break;
            case resourceType.sidr:
                Sidr += Mathf.RoundToInt((getOrLose ? amount : -amount) * sidrEventMultiplier);
                WriteResourceValues(resourceType.sidr);
                break;
            case resourceType.civilians:
                Civilians += Mathf.RoundToInt((getOrLose ? (Civilians + amount < Village.civilianLimit ? amount : Village.civilianLimit - Civilians) : -amount) * civiliansEventMultiplier);
                Garden.UpdateCiviliansAmount(Civilians);

                WriteResourceValues(resourceType.civilians);
                break;
            case resourceType.warriors:
                Warriors += Mathf.RoundToInt((getOrLose ? (Warriors + amount < Village.warriorLimit ? amount : Village.warriorLimit - Warriors) : -amount) * warriorsEventMultiplier);

                WriteResourceValues(resourceType.warriors);
                break;
        }

        if (getOrLose)
        {
            switch (resource)
            {
                case resourceType.apples:
                    AllApples += amount;
                    break;
                case resourceType.sidr:
                    AllSidr += amount;
                    break;
                case resourceType.civilians:
                    AllCivilians += amount;
                    break;
                case resourceType.warriors:
                    AllWarrios += amount;
                    break;
            }
        }
    }

    public int GetResourceValue(resourceType resource)
    {
        switch (resource)
        {
            case resourceType.apples:
                return Apples;
            case resourceType.sidr:
                return Sidr;
            case resourceType.civilians:
                return Civilians;
            case resourceType.warriors:
                return Warriors;
        }

        return 0;
    }


    /// <summary>
    /// Checks if there is more or eaqual to "reqiredAmount" of some "resource"
    /// </summary>
    /// <param name="resource"></param>
    /// <param name="requiredAmout"></param>
    /// <returns></returns>
    public bool CheckResourceAmount(resourceType resource, int requiredAmout)
    {
        switch (resource)
        {
            case resourceType.apples:
                return Apples >= requiredAmout;
            case resourceType.sidr:
                return Sidr >= requiredAmout;
            case resourceType.civilians:
                return Civilians >= requiredAmout;
            case resourceType.warriors:
                return Warriors >= requiredAmout;
        }

        return false;
    }

    /// <summary>
    /// Checks if civilians or warriors are at their limit
    /// </summary>
    /// <param name="resource"></param>
    /// <returns></returns>
    public bool IsAtLimit(resourceType resource)
    {
        switch (resource)
        {
            case resourceType.civilians:
                return Civilians == Village.civilianLimit;
            case resourceType.warriors:
                return Warriors == Village.warriorLimit;
        }

        return false;
    }

    /// <summary>
    /// Consumes one 'sidr' per every 'warrior'
    /// </summary>
    public void DrinkSidr()
    {
        Sidr -= Warriors;

        ConsumedSidr += Warriors + Sidr;

        if (Sidr < 0)
        {
            Warriors += Sidr;

            FallenWarriors += Mathf.Abs(Sidr);

            Sidr = 0;
        }

        WriteResourceValues(resourceType.sidr);
        WriteResourceValues(resourceType.warriors);
    }

    /// <summary>
    /// Counts war results
    /// </summary>
    /// <param name="enemyAmount"></param>
    public void War(int enemyAmount)
    {
        Warriors -= (enemyAmount - Tower.warriorsAmount);
        FallenWarriors += (enemyAmount - Tower.warriorsAmount) + Warriors;
        OvercomeEnemiesCount += (enemyAmount - Tower.warriorsAmount) + Warriors;
        if (Warriors < 0)
        {
            Civilians += Warriors * 2;

            FallenCivilians += Mathf.Abs(Warriors * 2) + Civilians;
            OvercomeEnemiesCount += (Mathf.Abs(Warriors * 2) + Civilians) / 2;

            Warriors = 0;
            if (Civilians < 1)
            {
                Civilians = 0;
                Lose();
            }

            Garden.UpdateCiviliansAmount(Civilians);
        }
        OvercomeWavesCount++;

        WriteResourceValues(resourceType.civilians);
        WriteResourceValues(resourceType.warriors);
    }

    public void Win()
    {
        PauseButton.SetActive(false);
        Pause.isPaused = true;
        WinPanel.SetActive(true);
        WinPanel.GetComponent<CountStats>().PrintStats(AllApples, AllSidr, AllCivilians, AllWarrios, ConsumedSidr, FallenCivilians, FallenWarriors, OvercomeWavesCount, OvercomeEnemiesCount);
    }

    public void Lose()
    {
        PauseButton.SetActive(false);
        Pause.isPaused = true;
        LosePanel.SetActive(true);
        LosePanel.GetComponent<CountStats>().PrintStats(AllApples, AllSidr, AllCivilians, AllWarrios, ConsumedSidr, FallenCivilians, FallenWarriors, OvercomeWavesCount, OvercomeEnemiesCount);
    }


    /// <summary>
    /// Writes "resource" values in the GUI field
    /// </summary>
    /// <param name="resource"></param>
    private void WriteResourceValues(resourceType resource)
    {
        switch (resource)
        {
            case resourceType.apples:
                ApplesGUI.text = Apples.ToString();
                break;
            case resourceType.sidr:
                SidrGUI.text = Sidr.ToString();
                break;
            case resourceType.civilians:
                CiviliansGUI.text = Civilians.ToString() + " I " + Village.civilianLimit.ToString();
                break;
            case resourceType.warriors:
                WarriorsGUI.text = Warriors.ToString() + " I " + Village.warriorLimit.ToString();
                break;
        }
    }

    public void MultiplyResourceEventMultiplier(resourceType resource, float multiplier)
    {
        switch (resource)
        {
            case resourceType.apples:
                applesEventMultiplier *= multiplier;
                if (applesEventMultiplier != 1)
                {
                    ApplesEventMultiplierGUI.text = Mathf.RoundToInt(applesEventMultiplier * 100).ToString() + "%";
                }
                else
                {
                    ApplesEventMultiplierGUI.text = string.Empty;
                }
                break;
            case resourceType.sidr:
                sidrEventMultiplier *= multiplier;
                if (sidrEventMultiplier != 1)
                {
                    SidrEventMultiplierGUI.text = Mathf.RoundToInt(sidrEventMultiplier * 100).ToString() + "%";
                }
                else
                {
                    SidrEventMultiplierGUI.text = string.Empty;
                }
                break;
            case resourceType.civilians:
                civiliansEventMultiplier *= multiplier;
                if (civiliansEventMultiplier != 1)
                {
                    CiviliansEventMultiplierGUI.text = Mathf.RoundToInt(civiliansEventMultiplier * 100).ToString() + "%";
                }
                else
                {
                    CiviliansEventMultiplierGUI.text = string.Empty;
                }
                break;
            case resourceType.warriors:
                warriorsEventMultiplier *= multiplier;
                if (warriorsEventMultiplier != 1)
                {
                    WarriorsEventMultiplierGUI.text = Mathf.RoundToInt(warriorsEventMultiplier * 100).ToString() + "%";
                }
                else
                {
                    WarriorsEventMultiplierGUI.text = string.Empty;
                }
                break;
        }
    }
}
