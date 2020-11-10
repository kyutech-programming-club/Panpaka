using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class results : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("results");
    }
}