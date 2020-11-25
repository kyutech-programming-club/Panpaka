using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    Text RankingText;
    void Start()
    {
        RankingText = GetComponent<Text>();
        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("Result");
        query.WhereEqualTo("stageId", 1);
        query.OrderByAscending("time");
        query.Limit = 5;
        query.FindAsync((List<NCMBObject> objList, NCMBException err) =>
        {
            if (err == null)
            {
                RankingText.text = "";
                for (int i = 0; i < Mathf.Min(objList.Count, 5); i++)
                {
                    RankingText.text += "#" + (i + 1) + ": " + objList[i]["uName"] + "   " + ConvertTimeToString(objList[i]["time"].ToString()) + "\n";
                }
            }
            else
            {
                Debug.Log("ERROR!ネットワーク接続に問題が発生しました。");
            }
        });
    }
    string ConvertTimeToString(string time)
    {
        float ftime = float.Parse(time);
        int minute = (int)ftime / 60;//分.timeを60で割った値.
        int second = (int)ftime % 60;//秒.timeを60で割った余り.
        int msecond = (int)(ftime * 100 % 100);
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
}
