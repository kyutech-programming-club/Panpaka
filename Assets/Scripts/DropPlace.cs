using UnityEngine;
using UnityEngine.EventSystems;

public class DropPlace : MonoBehaviour, IDropHandler
{
    public GameObject C;
    // public GameObject Controller;
    public void OnDrop(PointerEventData data){
        Debug.Log(gameObject.name);

        CardMovement dragObj = data.pointerDrag.GetComponent<CardMovement>();
        if(dragObj != null){
            dragObj.parentTransform = this.transform;
            Debug.Log(gameObject.name+"に"+data.pointerDrag.name+"をドロップ");
            if(dragObj.CompareTag("right"))
                {
                     C.transform.Translate(1,0,0);
                    // Controller.GetComponent<UnityChan2DController>().Move(5.0f,false);
                }
            if(dragObj.CompareTag("left"))
                {
                     C.transform.Translate(-1,0,0);
                    // Controller.GetComponent<UnityChan2DController>().Move(5.0f,false);
                }
            if(dragObj.CompareTag("up"))
                {
                     C.transform.Translate(0,1,0);
                    // Controller.GetComponent<UnityChan2DController>().Move(5.0f,false);
                }
            if(dragObj.CompareTag("down"))
                {
                     C.transform.Translate(0,-1,0);
                    // Controller.GetComponent<UnityChan2DController>().Move(5.0f,false);
                }
        }

    }
}
