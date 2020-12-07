using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {
    public Transform parentTransform;
    public GameObject target;
    public GameObject C;

    public void OnBeginDrag(PointerEventData data){
        Debug.Log("OnBeginDrag");
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        parentTransform = transform.parent;
        transform.SetParent(transform.parent.parent);
        if (gameObject.name == "if")
        {
            C.GetComponent<UnityChanAttempt>().DeactivateOnCollisionStay();
            C.GetComponent<UnityChanAttempt>().DeactivateOnCollisionStayOnWhile();
        }
    }
    public void OnDrag(PointerEventData data){
        transform.position = data.position;
    }

    public void OnEndDrag(PointerEventData data){
        Debug.Log("OnEndDrag");
        transform.SetParent(parentTransform);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }    
}