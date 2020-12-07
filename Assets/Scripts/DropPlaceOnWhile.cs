using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class DropPlaceOnWhile : MonoBehaviour, IDropHandler
{
    public GameObject C;
    public GameObject childObject;
    public Transform parent;
    string ToDoTaskName = "";

    void FixedUpdate()
    {
        if (gameObject.transform.childCount == 0)
        {
            ToDoTaskName = "";
        }
        switch (ToDoTaskName)
        {
            case "right":
                C.GetComponent<UnityChanAttempt>().RightRunOnWhile();
                break;
            case "left":
                C.GetComponent<UnityChanAttempt>().LeftRunOnWhile();
                break;
            default:
                break;
        }
    }


    public void OnDrop(PointerEventData data)
    {
        Debug.Log(gameObject.name);

        CardMovement dragObj = data.pointerDrag.GetComponent<CardMovement>();
        if (dragObj != null)
        {
            dragObj.parentTransform = this.transform;
            Debug.Log(gameObject.name + "に" + data.pointerDrag.name + "をドロップ(while)");
            if (dragObj.tag == "if")
            {
                C.GetComponent<UnityChanAttempt>().ActivateOnCollisionStayOnWhile();
            }
            else 
            {
                ToDoTaskName = dragObj.tag;
            }
            
        }
    }
}
