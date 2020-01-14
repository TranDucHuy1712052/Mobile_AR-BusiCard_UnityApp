using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoShowingController : MonoBehaviour
{
    public Text titleText, t1Text, infoText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //================================
    //FUNCTIONS

    public void SetInfomation(string title, string t1, string info)
    {
        titleText.text = title;
        t1Text.text = t1;
        infoText.text = info;
    }
}
