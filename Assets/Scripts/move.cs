using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class move : MonoBehaviour, IDropHandler
{   
    public void OnDrop(PointerEventData data){
        Debug.Log(gameObject.name);

        CardMovement dragObj = data.pointerDrag.GetComponent<CardMovement>();
        if(dragObj != null){
            dragObj.parentTransform = this.transform;
            Debug.Log(gameObject.name+"に"+data.pointerDrag.name+"をドロップ(move)");
        }
    }

}
