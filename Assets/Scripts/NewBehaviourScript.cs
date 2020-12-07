using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {
 

    public GameObject childObject;
    public Transform parent;
    public Text text;
    public GameObject C;
    public static float time;
    public int stageId;

    void Start()
    {
        StageManager.StageId = stageId;
        time = 0;
    }

    void Update()
    {
        time += Time.deltaTime;//毎フレームの時間を加算.
        int minute = (int)time / 60;//分.timeを60で割った値.
        int second = (int)time % 60;//秒.timeを60で割った余り.
        int msecond = (int)(time * 100 % 100);
        string minText, secText, msecText;//テキスト形式の分・秒を用意.
        if (minute < 10)
            minText = "0" + minute.ToString();//("0"埋め), ToStringでint→stringに変換.
        else
            minText = minute.ToString();
        if (second < 10)
            secText = "0" + second.ToString();//上に同じく.
        else
            secText = second.ToString();
        if (msecond < 10)
            msecText = "0" + msecond.ToString();
        else
            msecText = msecond.ToString();
        text.text = "[Time] " + minText + ":" + secText + "." + msecText;
        
    }

    public static float getTime()
    {
        return time;
    }


    //OnTriggerEnter関数
    //接触したオブジェクトが引数otherとして渡される
    void OnTriggerEnter2D(Collider2D other)
    {
        //接触したオブジェクトのタグが"Player"のとき
        if(other.gameObject.tag == "Player"){
            //オブジェクトの色を赤に変更する
            // GetComponent<Renderer>().material.color = Color.red;
            Instantiate (childObject, new Vector3(400,250,0), Quaternion.identity,parent);
            // Debug.Log("Hit");
            Time.timeScale = 0;
        }
    }
}