using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class Config
{
    //public static string BaseUrl = "http://192.168.1.82:3000/";                  //lưu ý: nếu muốn tự cài local hay cài đặt server, thay đổi cái này!
    public static string BaseUrl = "https://mobiledev-17cntn-arbusicard.herokuapp.com/";

    //API URL
    public static string GetDataAPI = "get-data";
    public static string AddDataAPI = "add-data";
    public static string GetVideoAPI = "get-video";

    //Positions
    public static Vector3 COOL_OBJECT_POSITION = new Vector3(230f, 0.01f, 0f);
}

