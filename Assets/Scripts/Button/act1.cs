using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class act1 : MonoBehaviour
{
    public GameObject a1;
    public GameObject a2;
    public Text a3;
    public Text a4;
    public Text a5;
    public Text a6;

    public void OnClickStartButton()
    {
        Destroy(a1);
        Destroy(a2);
        Destroy(a3);
        Destroy(a4);
        Destroy(a5);
        Destroy(a6);
    } 
}