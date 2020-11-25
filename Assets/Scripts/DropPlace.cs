using UnityEngine;
using UnityEngine.EventSystems;

public class DropPlace : MonoBehaviour, IDropHandler
{
    public GameObject C;
    public GameObject childObject;
    public Transform parent;

    public void OnDrop(PointerEventData data){
        Debug.Log(gameObject.name);

        CardMovement dragObj = data.pointerDrag.GetComponent<CardMovement>();
        if(dragObj != null){
            dragObj.parentTransform = this.transform;
            Debug.Log(gameObject.name+"に"+data.pointerDrag.name+"をドロップ");
            if(dragObj.CompareTag("right"))
                {
                    C.GetComponent<UnityChanAttempt>().RightRun();
                    //  C.transform.Translate(1,0,0);
                }
            if(dragObj.CompareTag("left"))
                {
                    if(C.transform.position.x <= -8)
                    {
                        Instantiate (childObject, new Vector3(400,250,0), Quaternion.identity,parent);
                    }
                    else
                    {
                        C.GetComponent<UnityChanAttempt>().LeftRun();
                        // C.transform.Translate(-1,0,0);
                        
                    }


                }
            if(dragObj.CompareTag("up"))
                {
                    C.GetComponent<UnityChanAttempt>().Jump();
                    //  C.transform.Translate(0,1,0);
                }
            if(dragObj.CompareTag("down"))
                {
                     C.transform.Translate(0,-1,0);
                }
        }

    }
}
