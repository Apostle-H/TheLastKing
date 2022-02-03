using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyExtensions
{
    public static int ElementsSum(this List<int> arr)
    {
        int res = 0;
        foreach (var el in arr)
        {
            res += el;
        }

        return res;
    }
}
