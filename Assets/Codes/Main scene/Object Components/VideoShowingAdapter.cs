using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoShowingAdapter : MonoBehaviour
{
    public Text titleText;
    public VideoPlayer vidPlayer;
    public VideoPlaybackController controller;
    //public Text warningText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInfomation(string title, string vid_id)
    {
        titleText.text = title;
        vidPlayer.source = VideoSource.Url;
        vidPlayer.url = Config.BaseUrl + Config.GetVideoAPI 
            + "?vid_id=" + vid_id;

        // vidPlayer.Play();
        StartCoroutine(controller.playVideo());
    }
}
