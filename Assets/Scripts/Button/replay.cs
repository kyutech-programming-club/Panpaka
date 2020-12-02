using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class replay : MonoBehaviour
{
    public void OnClickStartButton()
    {
        StageManager.StageId = 1;
        SceneManager.LoadScene("stage");
    }
}