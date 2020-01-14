using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class InfoObj_ExitCube : MonoBehaviour
{
    GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = this.gameObject.transform.parent.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == this.gameObject.transform)
                {
                    Destroy(parent);
                }
                    
            }
        }
    }
}
