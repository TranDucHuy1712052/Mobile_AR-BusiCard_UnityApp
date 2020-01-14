using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable]
//public struct Job
//{
//    string nameOfWorkspace;
//    string job;
//    string description;

//    public Job(string nameOfWorkspace, string job, string description)
//    {
//        this.nameOfWorkspace = nameOfWorkspace;
//        this.job = job;
//        this.description = description;
//    }
//}

//[System.Serializable]
//public struct Education
//{
//    string nameOfSchool;
//    string description;

//    public Education(string nameOfSchool, string description)
//    {
//        this.nameOfSchool = nameOfSchool;
//        this.description = description;
//    }
//}

//[System.Serializable]
//public struct Contact
//{
//    string email;
//    string phoneNumber;
//    string address;

//    public Contact(string email, string phoneNumber, string address)
//    {
//        this.email = email;
//        this.phoneNumber = phoneNumber;
//        this.address = address;
//    }
//}

//=====================================
//main class to contain infomation of 1 user, to show outside.
[System.Serializable]
public class User
{
    public int id;                 //so tang dan
    public string name;
    public string intro;

    //Job (workspace, job, descption)
    //public Job job;
    public string workspace;
    public string job;
    public string job_description;

    //education (school, description)
    //public Education education;
    public string school;
    public string school_description;

    //Contact (email, phonenumber, address)
    //public Contact contact;
    public string email;
    public string phonenumber;
    public string address;

    //Skill (skill, description)
    public string[] skill_name;
    public string skill_description;

    public string[] achievements;
    public string[] videos;                         //urls

    //CONSTRUCTOR ========================



    public User(int id, string name, string intro,
        string workspace, string job, string job_description,
        string school, string school_description,
        string email, string phonenumber, string address,
        string[] skill_name, string skill_description,
        string[] achievements, string[] videos
    )
    {
        this.id = id;
        this.name = name;
        this.intro = intro;

        this.workspace = workspace;
        this.job = job;
        this.job_description = job_description;

        this.school = school;
        this.school_description = school_description;

        this.email = email;
        this.phonenumber = phonenumber;
        this.address = address;

        this.skill_name = skill_name;
        this.skill_description = skill_description;

        this.achievements = achievements;
        this.videos = videos;
    }

    // Copy constructor
    public User(User u2)
    {
        id = u2.id;
        name = u2.name;
        intro = u2.intro;

        workspace = u2.workspace;
        job = u2.job;
        job_description = u2.job_description;

        school = u2.school;
        school_description = u2.school_description;

        email = u2.email;
        phonenumber = u2.phonenumber;
        address = u2.address;

        skill_name = u2.skill_name;
        skill_description = u2.skill_description;

        achievements = u2.achievements;
        videos = u2.videos;
    }
    //From JSON constructor
    public User(string json)
    {
        User u2 = JsonUtility.FromJson<User>(json);

        id = u2.id;
        name = u2.name;
        intro = u2.intro;

        workspace = u2.workspace;
        job = u2.job;
        job_description = u2.job_description;

        school = u2.school;
        school_description = u2.school_description;

        email = u2.email;
        phonenumber = u2.phonenumber;
        address = u2.address;

        skill_name = u2.skill_name;
        skill_description = u2.skill_description;

        achievements = u2.achievements;
        videos = u2.videos;
    }
    

    //CHANGE TO JSON ========================================

    public string ToJSON()
    {
        string json = JsonUtility.ToJson(this);
        return json;
    }
}
