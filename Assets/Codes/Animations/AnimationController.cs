using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public int mode = 1;           //1 = spin
    GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        obj = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        switch (mode)
        {
            case 1:
                {
                    Vector3 movement = new Vector3(0f, 0f, 1f);
                    obj.transform.Rotate(movement);
                    break;
                }
        }
    }
}
