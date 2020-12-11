using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DropAndCopyInStage : MonoBehaviour, IDropHandler
{
    public Transform parent;
    public GameObject floor;

    private Dictionary<string, GameObject> GODic = new Dictionary<string, GameObject>();

    void Start()
    {
        GODic.Add("floor", floor);
    }

    public void OnDrop(PointerEventData data)
    {
        CardMovement dragObj = data.pointerDrag.GetComponent<CardMovement>();
        if (dragObj != null)
        {
            dragObj.parentTransform = this.transform;
            Debug.Log("ttt");
            GameObject clone = GODic[data.pointerDrag.tag];
            Instantiate(clone, clone.transform.position, Quaternion.identity, parent);
        }
    }

}
