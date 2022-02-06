using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : MonoBehaviour
{
    [SerializeField] private HeadQuaters HQ;

    private int CivilianLimit = 10;
    private int WarriorLimit = 10;

    public int civilianLimit { get { return CivilianLimit; } }
    public int warriorLimit { get { return WarriorLimit; } }

    public void ChangeLimit(int newCivilianLimit, int newWarriorLimit)
    {
        CivilianLimit = newCivilianLimit;
        WarriorLimit = newWarriorLimit;

        HQ.ManipulateResource(resourceType.civilians, 0, false);
        HQ.ManipulateResource(resourceType.warriors, 0, false);
    }
}
