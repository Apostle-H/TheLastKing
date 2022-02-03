using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeadQuaters : MonoBehaviour
{
    // resources
    private int food = 10;

    private int peasents = 0;
    private int warriors;

    // fields
    [SerializeField] private TextMeshProUGUI foodGUI;

    [SerializeField] private TextMeshProUGUI peasentsGUI;
    [SerializeField] private TextMeshProUGUI warriorsGUI;

    private void Start()
    {
        foodGUI.text = food.ToString();
        peasentsGUI.text = peasents.ToString();
        warriorsGUI.text = warriors.ToString();
    }

    public void StoreFood(int foodIncome)
    {
        food += foodIncome;
        Debug.Log(food);

        foodGUI.text = food.ToString();
    }

    public void PaySomeFood(int foodExpendeture)
    {
        food -= foodExpendeture;

        foodGUI.text = food.ToString();
    }

    public void HirePeasent(int peasentAmount)
    {
        peasents += peasentAmount;

        peasentsGUI.text = peasents.ToString();
    }

    public bool CanGetPeasent()
    {
        return food >= Woods.PeasentCost;
    }

    public void HireWarrior(int warriorsAmount)
    {
        warriors += warriorsAmount;

        warriorsGUI.text = warriors.ToString();
    }

    public bool CanTrainWarrior()
    {
        return food >= Barrack.WarriorCost;
    }
}
