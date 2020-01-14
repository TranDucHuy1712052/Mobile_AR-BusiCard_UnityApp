using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPopup_EventHandler : MonoBehaviour
{
    GameObject obj;
    public Text text;
    public ParticleSystem parSys;
    public AudioSource audioSource;
    SFXManager sfxManager;
    User u;
    bool enabled = false;

    // Start is called before the first frame update
    void Start()
    {
        obj = this.gameObject;
        audioSource = this.gameObject.GetComponent<AudioSource>();
        sfxManager = new SFXManager();
    }

    void Update()
    {
        u = MainController.GetActiveUser();
        if (u != null && enabled == false)
        //Destroy(obj);                   //loading xong, tự hủy
        {
            enabled = true;
            StartCoroutine(welcomeEffect());
        }
    }

    IEnumerator welcomeEffect()
    {
        parSys.Play();
        Debug.Log("Particle system : Started");

        text.text = "Welcome to my AR-BusiCard presentation!";
        AudioClip clip = MainController.resources.welcomeSFXs[0];
        //yield return new WaitForSeconds(0.01f);
        if (audioSource.isPlaying == false) audioSource.Play();
        Debug.Log("Audio Source : played");

        yield return new WaitForSeconds(3f);
        Destroy(obj);
    }
}
