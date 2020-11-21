﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour {

    //時間を記録する小数も入る変数.
    Text text;
    public GameObject C;
    public static float time;
    
    void Start () {
        text = GetComponent<Text>();//自分のインスペクター内からTextコンポーネントを取得.
        time = 0;
    }
	
    void Update () {      
            if(C.transform.position.x >= 2)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
                time += Time.deltaTime;//毎フレームの時間を加算.
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
            
        
        
    }

    public static float getTime()
    {
        return time;
    }

}