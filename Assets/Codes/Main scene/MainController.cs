using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using System.Collections;

//==============
//THIS CLASS CONTAINS INSTANCE OF ACTIVE USER, AS WELL AS MOST IMPORTANT FUNCTIONS.
//==============

public class MainController : MonoBehaviour
{
    public GameObject infoObjTemplate;
    public GameObject videoPlaybackTemplate;
    public static MainScene_Resources resources;
    public static AudioSource audioSource;
    public SFXManager sfxManager;

    //public GameObject mainImageTarget;
    public static User activeUser = null;                        //only 1 user can be detected.


    // Start is called before the first frame update
    void Start()
    {
        resources = this.gameObject.GetComponent<MainScene_Resources>();
        sfxManager = this.gameObject.GetComponent<SFXManager>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            sfxManager.playSFX(ref audioSource, resources.eventSFXs[0]);
    }


    //===============================
    //=== GET ACTIVE USER ===========



    //================================
    //==== USER MANAGING =============

    public static User GetActiveUser() {
        return activeUser;
    }
    public static void SetActiveUser(User u) {
        activeUser = u;
        Debug.Log("Active User changed. It's " + activeUser.ToJSON());
    }                   //singleton - only one instance is allowed


    //=================================
    //==== EVENT FUNCTIONS ============


    //==== VIDEOS ======

    public void CreateNewVideoPlaybackObject()
    {
        //Cái đầu = canvas, cái 2 = "tracker", cái 3 = imageTarget tương ứng.
        GameObject imageTarget = EventSystem.current.currentSelectedGameObject.
            transform.parent.gameObject.
            transform.parent.gameObject.
            transform.parent.gameObject;

        GameObject obj = Instantiate(videoPlaybackTemplate);
        SetVideoToPlaybackObject(obj);

        obj.transform.parent = imageTarget.transform;
        
        obj.transform.localScale = new Vector3(0.004f, 0.004f, 0.004f);
        obj.transform.localPosition = new Vector3(-0.5f, 0.2f, 0f);
        obj.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);

        //CustomTrackableEventHandler handler = imageTarget.GetComponent<CustomTrackableEventHandler>();
        //handler.AddNewTemporaryTrackable(ref obj);                  //thêm vào danh sách các obj tạm thời tồn tại

        
    }
    public void SetVideoToPlaybackObject(GameObject obj)
    {
        string title = "Video";
        User u = GetActiveUser();

        VideoShowingAdapter adapter = obj.GetComponent<VideoShowingAdapter>();
        //Videos[] chứa các mã vid_id, truy vấn trong server
        //chỉ cần gọi API trong VideoPlayer là được!
        adapter.SetInfomation(title, u.videos[0]);
    }



        //===== TEXT INFO ==========

    public void CreateNewInfoObject(string status)
    {
        //Cái đầu = canvas, cái 2 = "tracker", cái 3 = imageTarget tương ứng.
        GameObject imageTarget = EventSystem.current.currentSelectedGameObject.
            transform.parent.gameObject.
            transform.parent.gameObject.
            transform.parent.gameObject;

        GameObject obj = Instantiate(infoObjTemplate);
        obj.transform.parent = imageTarget.transform;

        obj.transform.localScale = new Vector3(0.002f, 0.002f, 0.002f);
        obj.transform.localPosition = new Vector3(-0.5f, 0.2f, 0f);
        obj.transform.localRotation = new Quaternion(0f, 0f, 0f, 0f);

        //CustomTrackableEventHandler handler = imageTarget.GetComponent<CustomTrackableEventHandler>();
        //handler.AddNewTemporaryTrackable(ref obj);
        //set information to object
        SetInfomationToInfoObject(obj, status);
    }

    //===================================
    //===== INFOMATION SHOWING ==========

    private void SetInfomationToInfoObject(GameObject obj, string status)
    {
        string title = null, t1 = null, info = null;
        User u = GetActiveUser();

        switch (status)
        {
            case "introduction":
                {
                    title = "Introduction";
                    info = u.intro;
                    break;
                }
            case "job":                     //
                {
                    title = "Job";
                    t1 = u.workspace + " \n " + u.job;
                    info = u.job_description;
                    break;
                }
            case "education":
                {
                    title = "Education";
                    t1 = u.school;
                    info = u.school_description;
                    break;
                }
            case "contact":
                {
                    title = "Contact";
                    t1 = null;
                    info = u.email + " \n " + u.phonenumber + " \n " + u.address;
                    break;
                }
            case "skills":
                {
                    title = "Skills";
                    t1 = "";
                    for (int i = 0; i < u.skill_name.Length; i++)
                        t1 += u.skill_name[i] + ", ";
                    info = u.skill_description;
                    break;
                }
            case "achievement":
                {
                    title = "Achievements";
                    t1 = null;
                    info = "";
                    for (int i = 0; i < u.achievements.Length; i++)
                        info += u.achievements[i] + " \n ";
                    break;
                }
            case "about":
                {
                    title = "About this app";
                    t1 = "Tran Duc Huy & Le Nguyen Tri \n Ho Chi Minh University of Science";
                    info = "Do an cuoi ki mon Lap trinh thiet bi di dong \n Lop Cu nhan tai nang 2017 \n Tran Duc Huy - 1712052 \n Le Nguyen Tri - 1712244";
                    break;
                }
        }
        InfoShowingController infoCtrl = obj.GetComponent<InfoShowingController>();
        infoCtrl.SetInfomation(title, t1, info);
    }
}
