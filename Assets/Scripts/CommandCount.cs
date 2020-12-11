using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandCount : MonoBehaviour
{
    public static int count { get; set; }

    public static void Add()
    {
        count++;
    }

    public static void Reset()
    {
        count = 0;
    }
}