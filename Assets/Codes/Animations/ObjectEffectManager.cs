using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Hoạt động bằng cách click chuot trai vào obj có component này.
//ĐẦU VÀO : INT MODE, INT TARGET_OBJ
// + MODE: 1 = drag, 2 = ??
// + TARGET_OBJ: 0 = chính nó, 1 = obj cha
public class ObjectEffectManager : MonoBehaviour
{
    GameObject obj, parentObj;
    public int mode = 1, target_mode = 1;
    public bool working = false;
    Vector3 screenPoint, offset;

    // Start is called before the first frame update
    void Start()
    {
        obj = this.gameObject;
        parentObj = obj.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
            
        //}
        //else
        //    working = false;
    }

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);
        foreach (RaycastHit hit in hits)
        {
            if (hit.transform == obj.transform)
            {
                working = true;
                screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

                offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            }
        }
    }

    //Mouse events
    void DragObject()
    {
        if (working)
        {
            Vector3 cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorScreenPoint) + offset;
           
            if (target_mode == 1)
            {
                parentObj.transform.position = cursorPosition;
            }
            else if (target_mode == 0)
            {
                obj.transform.position = cursorPosition;
            }
        }
    }

    private void OnMouseDrag()
    {
        DragObject();
    }

    private void OnMouseUp()
    {
        //DragObject();
        working = false;
    }
}
