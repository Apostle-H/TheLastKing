using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeadQuaters : MonoBehaviour
{
    // resources
    private int Apples = 10;
    private int Sidr = 0;

    private int Civilians = 5;
    private int Warriors;

    public int civilians { get { return Civilians; } }

    // resuorces GUI
    [SerializeField] private TextMeshProUGUI ApplesGUI;
    [SerializeField] private TextMeshProUGUI SidrGUI;

    [SerializeField] private TextMeshProUGUI CiviliansGUI;
    [SerializeField] private TextMeshProUGUI WarriorsGUI;

    // Buildings
    [SerializeField] Garden Garden;
    [SerializeField] Tower Tower;

    // 
    [SerializeField] private Village Village;
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject LosePanel;

    private void Start()
    {
        ApplesGUI.text = Apples.ToString();
        SidrGUI.text = Sidr.ToString();
        CiviliansGUI.text = Civilians.ToString() + "/" + Village.civilianLimit.ToString();
        WarriorsGUI.text = Warriors.ToString() + "/" + Village.warriorLimit.ToString();
    }

    public void ManipulateResource(resourceType resource, int amount, bool getOrLose)
    {
        switch (resource)
        {
            case resourceType.apples:
                Apples += getOrLose ? amount : -amount;
                ApplesGUI.text = Apples.ToString();
                break;
            case resourceType.sidr:
                Sidr += getOrLose ? amount : -amount;
                SidrGUI.text = Sidr.ToString();
                break;
            case resourceType.civilians:
                if (Civilians + amount <= Village.civilianLimit)
                {
                    Civilians += getOrLose ? amount : -amount;
                    Garden.UpdateCiviliansAmount(Civilians);
                }
                
                CiviliansGUI.text = Civilians.ToString() + "/" + Village.civilianLimit.ToString();
                break;
            case resourceType.warriors:
                if (Warriors + amount <= Village.warriorLimit)
                {
                    Warriors += getOrLose ? amount : -amount;
                }
               
                WarriorsGUI.text = Warriors.ToString() + "/" + Village.warriorLimit.ToString();
                break;
        }
    }

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

    public bool IsAtLimit(resourceType resource)
    {
        switch (resource)
        {
            case resourceType.apples:
                break;
            case resourceType.civilians:
                return Civilians == Village.civilianLimit;
            case resourceType.warriors:
                return Warriors == Village.warriorLimit;
        }

        return false;
    }

    public void DrinkSidr()
    {
        Sidr -= Warriors;

        if (Sidr < 0)
        {
            Warriors += Sidr;
            Sidr = 0;
        }

        SidrGUI.text = Sidr.ToString();
        WarriorsGUI.text = Warriors.ToString() + "/" + Village.warriorLimit.ToString();
    }

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

        CiviliansGUI.text = Civilians.ToString() + "/" + Village.civilianLimit.ToString();
        WarriorsGUI.text = Warriors.ToString() + "/" + Village.warriorLimit.ToString();
    }

    public void Win()
    {
        WinPanel.SetActive(true);
    }

    public void Lose()
    {
        LosePanel.SetActive(true);
    }
}
