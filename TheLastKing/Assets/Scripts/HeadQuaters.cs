using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeadQuaters : MonoBehaviour
{
    // resources
    private int food = 10;

    private int civilians = 0;
    private int warriors;

    // resuorces GUI
    [SerializeField] private TextMeshProUGUI foodGUI;

    [SerializeField] private TextMeshProUGUI civiliansGUI;
    [SerializeField] private TextMeshProUGUI warriorsGUI;

    // 
    [SerializeField] private Village village;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;

    public enum resourceType
    {
        food,
        civilians,
        warriors
    }

    private void Start()
    {
        foodGUI.text = food.ToString();
        civiliansGUI.text = civilians.ToString();
        warriorsGUI.text = warriors.ToString();
    }

    public void ManipulateResource(resourceType resource, int amount, bool getOrLose)
    {
        switch (resource)
        {
            case resourceType.food:
                food += getOrLose ? amount : -amount;
                foodGUI.text = food.ToString();
                break;
            case resourceType.civilians:
                if (civilians + amount <= village.CivilianLimit)
                {
                    civilians += getOrLose ? amount : -amount;
                }
                
                civiliansGUI.text = civilians.ToString() + "/" + village.CivilianLimit.ToString();
                break;
            case resourceType.warriors:
                if (warriors + amount <= village.WarriorLimit)
                {
                    warriors += getOrLose ? amount : -amount;
                }
               
                warriorsGUI.text = warriors.ToString() + "/" + village.WarriorLimit.ToString();
                break;
        }
    }

    public bool CheckResourceRequirements(resourceType resource, int requiredAmout)
    {
        switch (resource)
        {
            case resourceType.food:
                return food >= requiredAmout;
            case resourceType.civilians:
                return civilians >= requiredAmout;
            case resourceType.warriors:
                return warriors >= requiredAmout;
        }

        return false;
    }

    public bool IsAtLimit(resourceType resource)
    {
        switch (resource)
        {
            case resourceType.food:
                break;
            case resourceType.civilians:
                return civilians == village.CivilianLimit;
            case resourceType.warriors:
                return warriors == village.WarriorLimit;
        }

        return false;
    }

    public void War(int enemyAmount)
    {
        warriors -= enemyAmount;
        if (warriors < 0)
        {
            civilians += warriors * 2;
            warriors = 0;
            if (civilians < 1)
            {
                Lose();
                civilians = 0;
            }
        }

        civiliansGUI.text = civilians.ToString() + "/" + village.CivilianLimit.ToString();
        warriorsGUI.text = warriors.ToString() + "/" + village.WarriorLimit.ToString();
    }

    public void Win()
    {
        winPanel.SetActive(true);
    }

    public void Lose()
    {
        losePanel.SetActive(true);
    }
}
