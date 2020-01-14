using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CustomTrackableEventHandler : DefaultTrackableEventHandler
{
    public GameObject loadingPopupTemplate;
    private GameObject loadingPopup;

    protected override void OnTrackingFound()
    {
        Debug.Log("Detected : name = " + mTrackableBehaviour.name);
        loadingPopup = Instantiate(loadingPopupTemplate);
        loadingPopup.transform.parent = this.gameObject.transform;
        loadingPopup.transform.localPosition = new Vector3(0f, 0.2f, 0f);
        loadingPopup.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
        loadingPopup.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);

        if (mTrackableBehaviour.TrackableName == "ARBusiCard_TDHuy")
            GetActiveUserBaseOnCard(1);
        else if (mTrackableBehaviour.TrackableName == "ARBusiCard_LNTri")
            GetActiveUserBaseOnCard(2);

        //OnTrackableStateChanged(m_PreviousStatus, m_NewStatus);
        base.OnTrackingFound();
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();

        MainController.SetActiveUser(null);                     //không xuất hiện tracker => không có user
    }

    public void GetActiveUserBaseOnCard(int i)
    {
        Debug.Log("Detected : user " + i.ToString());
        string idJSON = "{ \"id\":\"" + i.ToString() + "\"}";
        Debug.Log("Request body : " + idJSON);
        StartCoroutine(APIHelper.GetUserData(Config.BaseUrl + Config.GetDataAPI, idJSON));
        // Delay delay = new Delay(1.0f);
    }
}
