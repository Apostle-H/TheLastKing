using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : MonoBehaviour
{
    private int civilianLimit = 10;
    private int warriorLimit = 10;

    public int CivilianLimit { get { return civilianLimit; } }
    public int WarriorLimit { get { return warriorLimit; } }

    [SerializeField] private Vector2 LevelsStats;

}
