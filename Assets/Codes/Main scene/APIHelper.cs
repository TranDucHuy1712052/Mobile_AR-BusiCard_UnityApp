using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class APIHelper : MonoBehaviour
{
   
    //Lay data ra string
    public static string GetResultFromRequest(UnityWebRequest req)
    {
        string response = System.Text.Encoding.UTF8.GetString(req.downloadHandler.data);
        return response;
    }

    static UnityWebRequest CreateApiRequest(string url, string method, object body)
    {
        string bodyString = null;
        if (body is string)
        {
            bodyString = (string)body;
        }
        else if (body != null)
        {
            bodyString = JsonUtility.ToJson(body);
        }

        var request = new UnityWebRequest();
        request.url = url;
        request.method = method;
        request.downloadHandler = new DownloadHandlerBuffer();
        request.uploadHandler = new UploadHandlerRaw(string.IsNullOrEmpty(bodyString) ? null : Encoding.UTF8.GetBytes(bodyString));
        request.SetRequestHeader("Accept", "application/json");
        request.SetRequestHeader("Content-Type", "application/json");
        request.timeout = 60;
        return request;
    }


    // HAM MOI - HIEU QUA
    static public IEnumerator GetUserData(string url, string bodyJsonString)
    {
        var request = new UnityWebRequest(url, "POST");                          //GET method
        byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyJsonString);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();        //quay lai

        Debug.Log("Status Code: " + request.responseCode);
        Debug.Log("QUERY = " + request.url);
        Debug.Log("RESULT STRING = " + GetResultFromRequest(request));

        User user = new User(JsonUtility.FromJson<User>( GetResultFromRequest(request) ) );
        Debug.Log("--- User get: " + user.name);
        MainController.SetActiveUser(user);                //gán người dùng 

        //return GetResultFromRequest(request);
    }
}
