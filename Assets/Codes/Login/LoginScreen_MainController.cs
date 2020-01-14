using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScreen_MainController : MonoBehaviour
{
    SceneManager sceneManager;

    // Start is called before the first frame update
    void Start()
    {
        sceneManager = new SceneManager();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitApp()
    {
        Application.Quit();
    }

    public void OpenMainScene()
    {
        SceneManager.LoadSceneAsync("MainScene");
    }
    public void OpenSettingScene()
    {
        SceneManager.LoadSceneAsync("SettingScene");
    }
}
