using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSFX(ref AudioSource source, AudioClip clip)
    {
        Debug.Log("Audio played : " + clip.name);
        source.clip = clip;
        //if (source.isPlaying)
        //    yield return null;
        source.Play();
    }
}
