using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeadQuaters : MonoBehaviour
{
    // resources
    private int Apples = 10;
    private int Sidr = 0;

    private int Civilians = 0;
    private int Warriors;

    // resuorces GUI
    [SerializeField] private TextMeshProUGUI ApplesGUI;
    [SerializeField] private TextMeshProUGUI SidrGUI;

    [SerializeField] private TextMeshProUGUI CiviliansGUI;
    [SerializeField] private TextMeshProUGUI WarriorsGUI;

    // 
    [SerializeField] private Village Village;
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject LosePanel;

    private void Start()
    {
        ApplesGUI.text = Apples.ToString();
        SidrGUI.text = Sidr.ToString();
        CiviliansGUI.text = Civilians.ToString() + "/" + Village.CivilianLimit.ToString();
        WarriorsGUI.text = Warriors.ToString() + "/" + Village.WarriorLimit.ToString();
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
                if (Civilians + amount <= Village.CivilianLimit)
                {
                    Civilians += getOrLose ? amount : -amount;
                }
                
                CiviliansGUI.text = Civilians.ToString() + "/" + Village.CivilianLimit.ToString();
                break;
            case resourceType.warriors:
                if (Warriors + amount <= Village.WarriorLimit)
                {
                    Warriors += getOrLose ? amount : -amount;
                }
               
                WarriorsGUI.text = Warriors.ToString() + "/" + Village.WarriorLimit.ToString();
                break;
        }
    }

    public bool CheckResourceRequirements(resourceType resource, int requiredAmout)
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
                return Civilians == Village.CivilianLimit;
            case resourceType.warriors:
                return Warriors == Village.WarriorLimit;
        }

        return false;
    }

    public void War(int enemyAmount)
    {
        Warriors -= enemyAmount;
        if (Warriors < 0)
        {
            Civilians += Warriors * 2;
            Warriors = 0;
            if (Civilians < 1)
            {
                Lose();
                Civilians = 0;
            }
        }

        CiviliansGUI.text = Civilians.ToString() + "/" + Village.CivilianLimit.ToString();
        WarriorsGUI.text = Warriors.ToString() + "/" + Village.WarriorLimit.ToString();
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
