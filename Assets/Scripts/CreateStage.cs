using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;

public class CreateStage : MonoBehaviour
{
    public GameObject floor;
    private string objectId = "fAFIouZv7MMHL0HA";
    private Dictionary<string, GameObject> GoDic = new Dictionary<string, GameObject>();

    void Awake()
    {
        GoDic.Add("floor", floor);

        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("Stage");
        query.OrderByDescending("createDate");
        query.Limit = 1;
        query.FindAsync((List<NCMBObject> objList, NCMBException err) =>
        {
            if (err == null)
            {
                objectId = objList[0].ObjectId;
                Debug.Log(objectId);
                NCMBObject obj = new NCMBObject("Stage");
                obj.ObjectId = objectId;
                obj.FetchAsync((NCMBException e) => {
                    if (e != null)
                    {
                        //エラー処理
                        Debug.Log("errrrrrrrrr(create stage)");
                    }
                    else
                    {
                        //成功時の処理
                        Debug.Log("success(create stage)");
                        InstantiateObjects((ArrayList)obj["objects"]);
                    }
                });
            }
            else
            {
                Debug.Log("ERROR!ネットワーク接続に問題が発生しました。");
            }
        });
    }

    void InstantiateObjects(ArrayList myList)
    {
        for (int i = 0;i < myList.Count;i++)
        {
            dynamic obj = myList[i];
            Instantiate(GoDic[obj["objName"]],
            new Vector3(float.Parse(obj["x"].ToString()),
                        float.Parse(obj["y"].ToString()),
                        float.Parse(obj["z"].ToString())),
            Quaternion.identity,
            gameObject.transform);
        }
    }
}
