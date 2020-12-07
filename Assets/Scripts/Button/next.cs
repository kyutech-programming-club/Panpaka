using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class next : MonoBehaviour
{
    public void OnClickStartButton()
    {
        if(StageManager.StageId == 1)
        {
            SceneManager.LoadScene("stage2");
        }
        if(StageManager.StageId == 2)
        {
            SceneManager.LoadScene("stage3");
        }
        if(StageManager.StageId == 3)
        {
            SceneManager.LoadScene("stage4");
        }
        if(StageManager.StageId == 4)
        {
            SceneManager.LoadScene("stage5");
        }
    }
}