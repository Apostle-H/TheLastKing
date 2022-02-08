using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : MonoBehaviour
{
    [SerializeField] private HeadQuaters HQ;

    [SerializeField] private CiviliansWarriorsAmount CiviliansWarriorsAmount;

    public int civilianLimit { get { return CiviliansWarriorsAmount.Civilians; } }
    public int warriorLimit { get { return CiviliansWarriorsAmount.Warriors; } }

    public void ChangeLimit(int newCivilianLimit, int newWarriorLimit)
    {
        CiviliansWarriorsAmount.Civilians = newCivilianLimit;
        CiviliansWarriorsAmount.Warriors = newWarriorLimit;

        HQ.ManipulateResource(resourceType.civilians, 0, false);
        HQ.ManipulateResource(resourceType.warriors, 0, false);
    }
}
