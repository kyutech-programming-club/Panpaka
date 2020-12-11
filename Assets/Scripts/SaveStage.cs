using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;


public class SaveStage : MonoBehaviour
{
    public GameObject StageObj;

    public void OnClick()
    {
        GameObject[] ChildObjects = new GameObject[StageObj.transform.childCount];

        for (int i = 0; i < StageObj.transform.childCount; i++)
        {
            ChildObjects[i] = StageObj.transform.GetChild(i).gameObject;
            Debug.Log(ChildObjects[i].name);
        }

        List<Dictionary<string, string>> objects = new List<Dictionary<string, string>>();
        
        foreach (GameObject child in ChildObjects)
        {
            Dictionary<string, string> obj = new Dictionary<string, string>();
            obj.Add("objName", child.tag);
            obj.Add("x", child.transform.position.x.ToString());
            obj.Add("y", child.transform.position.y.ToString());
            obj.Add("z", child.transform.position.z.ToString());
            objects.Add(obj);
        }

        NCMBObject stage = new NCMBObject("Stage");
        stage["uName"] = NCMBUser.CurrentUser.UserName;
        stage["objects"] = objects;
        stage["stageName"] = "初めてのステージ";

        stage.SaveAsync((NCMBException e) =>
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
