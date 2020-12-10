using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DropAndCopy : MonoBehaviour, IDropHandler
{
    public Transform parent;
    public GameObject right;
    public GameObject left;
    public GameObject jump;
    public GameObject down;
    public GameObject rightRun;
    public GameObject leftRun;
    public GameObject _whileWithRun;
    public GameObject _if;

    private Dictionary<string, GameObject> GODic = new Dictionary<string, GameObject>();

    void Start()
    {
        GODic.Add("right", right);
        GODic.Add("left", left);
        GODic.Add("rightRun", rightRun);
        GODic.Add("leftRun", leftRun);
        GODic.Add("up", jump);
        GODic.Add("down", down);
        GODic.Add("while", _whileWithRun);
        GODic.Add("if", _if);
    }

    public void OnDrop(PointerEventData data)
    {
        CardMovement dragObj = data.pointerDrag.GetComponent<CardMovement>();
        if (dragObj != null)
        {
            dragObj.parentTransform = this.transform;
            Debug.Log(gameObject.name + "に" + data.pointerDrag.name + "をドロップ(dropandcopy)");

            
            GameObject clone = GODic[data.pointerDrag.tag];
            Debug.Log(clone.transform.position);
            Instantiate(clone, clone.transform.position, Quaternion.identity, parent);
        }
    }

}
