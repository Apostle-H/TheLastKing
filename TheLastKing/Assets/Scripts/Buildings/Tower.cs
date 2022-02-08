using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tower : MonoBehaviour
{
    [SerializeField] private HeadQuaters HQ;

    [SerializeField] private int WarriorsLimit;

    [SerializeField] private Button AddWarriorButton;
    [SerializeField] private TextMeshProUGUI WarriorsInGUI;

    public int warriorsLimit { get { return WarriorsLimit; } }

    private int WarriorsAmount;

    public int warriorsAmount { get { return WarriorsAmount; } set { WarriorsAmount = value > WarriorsLimit ? WarriorsLimit : value; } }

    private void Start()
    {
        WarriorsInGUI.text = WarriorsAmount.ToString() + "/" + WarriorsLimit.ToString();
    }

    private void Update()
    {
        AddWarriorButton.interactable = HQ.CheckResourceAmount(resourceType.warriors, 1) && WarriorsAmount < WarriorsLimit;
    }

    public void AddWarrior()
    {
        HQ.ManipulateResource(resourceType.warriors, 1, false);
        WarriorsAmount++;

        WarriorsInGUI.text = WarriorsAmount.ToString() + "/" + WarriorsLimit.ToString();
    }

    public void ChangeLimit(int newWarriorLimit)
    {
        WarriorsLimit = newWarriorLimit;

        WarriorsInGUI.text = WarriorsAmount.ToString() + "/" + WarriorsLimit.ToString();
    }
}
