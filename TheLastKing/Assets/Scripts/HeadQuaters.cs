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

    [Header("Buildings")]
    [SerializeField] Garden Garden;
    [SerializeField] Tower Tower; 
    [SerializeField] private Village Village;

    [Header("Win/Lose panels")] 
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject LosePanel;

    // Properties
    public int apples { get { return Apples; } }
    public int sidr { get { return Sidr; } }
    public int civilians { get { return Civilians; } }
    public int warriors { get { return Warriors; } }

    private void Start()
    {
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
                Apples += getOrLose ? amount : -amount;
                WriteResourceValues(resourceType.apples);
                break;
            case resourceType.sidr:
                Sidr += getOrLose ? amount : -amount;
                WriteResourceValues(resourceType.sidr);
                break;
            case resourceType.civilians:
                if (Civilians + amount <= Village.civilianLimit)
                {
                    Civilians += getOrLose ? amount : -amount;
                    Garden.UpdateCiviliansAmount(Civilians);
                }

                WriteResourceValues(resourceType.civilians);
                break;
            case resourceType.warriors:
                if (Warriors + amount <= Village.warriorLimit)
                {
                    Warriors += getOrLose ? amount : -amount;
                }

                WriteResourceValues(resourceType.warriors);
                break;
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

        if (Sidr < 0)
        {
            Warriors += Sidr;
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
        if (Warriors < 0)
        {
            Civilians += Warriors * 2;
            Warriors = 0;
            if (Civilians < 1)
            {
                Lose();
                Civilians = 0;
            }

            Garden.UpdateCiviliansAmount(Civilians);
        }

        WriteResourceValues(resourceType.civilians);
        WriteResourceValues(resourceType.warriors);
    }

    public void Win()
    {
        WinPanel.SetActive(true);
    }

    public void Lose()
    {
        LosePanel.SetActive(true);
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
                CiviliansGUI.text = Civilians.ToString() + "/" + Village.civilianLimit.ToString();
                break;
            case resourceType.warriors:
                WarriorsGUI.text = Warriors.ToString() + "/" + Village.warriorLimit.ToString();
                break;
        }
    }
}
