using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoPlaybackController : MonoBehaviour
{
    VideoPlayer vidPlayer;
    AudioSource audioSource;
    public GameObject playButton;
    public Text warningText;

    // Start is called before the first frame update
    void Start()
    {
        //InitializeVideoPlayer();
        playButton.SetActive(false);
        //InitializeVideoPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (vidPlayer.isPlaying)
            Debug.Log("Vid player frame : " + vidPlayer.frame);
        else
            Debug.LogWarning("Vid player paused !!!");
    }

    void InitializeVideoPlayer()
    {
        vidPlayer = this.gameObject.GetComponent<VideoPlayer>();
        audioSource = gameObject.AddComponent<AudioSource>();
        
        vidPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

        vidPlayer.EnableAudioTrack(0, true);
        vidPlayer.SetTargetAudioSource(0, audioSource);
    }

    public IEnumerator playVideo()
    {
        InitializeVideoPlayer();
        
        vidPlayer.Prepare();

        //Wait until video is prepared
        while (!vidPlayer.isPrepared)
        {
            //Debug.Log("Preparing Video");
            yield return null;
        }

        WaitForSeconds sec = new WaitForSeconds(8f);
        yield return sec;

        warningText.text = "Video loaded.";

        vidPlayer.Play();
        audioSource.Play();
    }

    private void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] raycastHits = Physics.RaycastAll(ray);

        foreach (RaycastHit hit in raycastHits)
        {
            if (hit.transform == this.gameObject.transform)
            {
                if (vidPlayer.isPlaying)
                {
                    vidPlayer.Pause();
                    playButton.SetActive(true);
                }
                else
                {
                    playButton.SetActive(false);
                    vidPlayer.Play();
                }
            }
        }
    }
}
