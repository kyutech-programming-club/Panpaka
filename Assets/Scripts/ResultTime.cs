using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultTime : MonoBehaviour
{
    float time;
    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        time = TimeCount.getTime();
        int minute = (int)time/60;//分.timeを60で割った値.
        int second = (int)time%60;//秒.timeを60で割った余り.
        int msecond = (int)(time*100%100);
        string minText, secText, msecText;//テキスト形式の分・秒を用意.
        
        if (minute < 10)
            minText = "0" + minute.ToString();//("0"埋め), ToStringでint→stringに変換.
        else
            minText = minute.ToString();
        
	    if (second < 10)
            secText = "0" + second.ToString();//上に同じく.
        else
            secText = second.ToString();

        if(msecond < 10)
            msecText = "0" + msecond.ToString ();
        else
            msecText = msecond.ToString ();

        text.text = "[Time] " + minText + ":" + secText + "." + msecText ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
