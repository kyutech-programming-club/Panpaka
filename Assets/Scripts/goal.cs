﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class goal : MonoBehaviour, IDropHandler
{   
    bool One;
    public GameObject childObject;
    public Transform parent;
 
    void Start()
    {
        One = true;
    }
    void Update() {
 
        // transformを取得
        Transform myTransform = this.transform;
        // 座標を取得
        Vector3 pos = myTransform.position;

        if(myTransform.position.x == 550)
        {   
            if(One){
                //Debug.Log("hit");
                Instantiate (childObject, new Vector3(400,250,0), Quaternion.identity,parent);
                One = false;
            }
        }
    }

    public void OnDrop(PointerEventData data){
        Debug.Log(gameObject.name);

        CardMovement dragObj = data.pointerDrag.GetComponent<CardMovement>();
        if(dragObj != null){
            dragObj.parentTransform = this.transform;
            Debug.Log(gameObject.name+"に"+data.pointerDrag.name+"をドロップ");
        }
    }

}