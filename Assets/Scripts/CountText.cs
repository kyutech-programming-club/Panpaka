using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountText : MonoBehaviour
{
    public Text text;

    void Start()
    {
    }


    void Update()
    {
        text.text = CommandCount.count.ToString();
    }
}
