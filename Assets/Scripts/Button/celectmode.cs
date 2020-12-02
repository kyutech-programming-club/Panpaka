using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class celectmode : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("celectstage");
    }
}
