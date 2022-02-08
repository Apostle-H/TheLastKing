using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CiviliansWarriorsAmount 
{
    public int Civilians;
    public int Warriors;
}

[System.Serializable]
public struct ResourceAndValue
{
    public resourceType resource;
    public float value;
}

[System.Serializable]
public struct BuildingAndValue
{
    public ResourceProducer building;
    public float value;
}
