using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class ResultTime : MonoBehaviour
{
    float time;
    int commandCount;
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
        time = NewBehaviourScript.getTime();
        commandCount = CommandCount.count;


        text.text = "[時間] " + ChangeTimeToString(time);
        text.text += "\n[コマンド回数] " + commandCount.ToString();
        text.text += "\n================";
        text.text += "\n[点数] " + ChangeTimeToString(time + (float)(commandCount*5));

        SaveResult(time);
    }

    string ChangeTimeToString(float time)
    {
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

        return minText + ":" + secText + "." + msecText;
    }

    void SaveResult(float time)
    {
        NCMBObject result = new NCMBObject("Result");
        result["uName"] = NCMBUser.CurrentUser.UserName;
        result["time"] = time;
        result["stageId"] = StageManager.StageId;

        result.SaveAsync((NCMBException e) =>
        {
            if (e != null)
            {
                //エラー
                Debug.Log("errrr");
            }
            else
            {
                //成功時の処理
                Debug.Log("successsss");
            }
        });
    }
}
