using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;
using Debug = UnityEngine.Debug;


public class PointerHandler : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;

    

    public GameObject Sphere1;
    public GameObject Sphere2;
    public GameObject Sphere3;
    public GameObject Sphere4;
    public GameObject Sphere5;
    public GameObject Sphere6;
    public GameObject Sphere7;
    public GameObject Sphere8;
    public GameObject Sphere9;
    public GameObject Sphere10;
    public GameObject Sphere11;
    public GameObject Sphere12;
    public GameObject Sphere13;

   
    SteamVR_LaserPointer Pointer;


    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }
    // PointerClick handles all Interaction with Objects using a raycast.
    public void PointerClick(object sender, PointerEventArgs e)
    {

        //// Button in Intro Screen --> moves to next Screen in the Intro
        //if (e.target.name == "Next")
        //{
        //    if (Intro)
        //    {
        //        Intro.SetActive(false);
        //        Task.SetActive(true);
        //    }

        //}

        //// Button in Intro Screen --> Skips intro direct to Game Start
        //if (e.target.name == "Skip") 
        //{
        //    if(Intro)
        //    {
        //        Intro.SetActive(false);
        //        StartScreen.SetActive(true);
        //    }

        //}

        //// Button in Intro Screen --> moves to next Screen in the Intro
        //if (e.target.name == "Next2") 
        //{
        //    if (Task)
        //    {
        //        Task.SetActive(false);
        //        Control.SetActive(true);
        //    }

        //}

        //// Button in Intro Screen --> moves to next Screen in the Intro
        //if (e.target.name == "Next3")
        //{
        //    if (Control)
        //    {
        //        Control.SetActive(false);
        //        UI.SetActive(true);
        //    }

        //}

        //// Button in Intro Screen --> moves to next Screen in the Intro
        //if (e.target.name == "Next4")
        //{
        //    if (UI)
        //    {
        //        UI.SetActive(false);
        //        StartScreen.SetActive(true);
        //        ScoreScript.checkTutorialDone();
        //    }

        //}

        //// Button in Intro Screen --> Starts Game Round
        //if (e.target.name == "Start")
        //{
        //    if (StartScreen)
        //    {
        //        StartScreen.SetActive(false);
        //        ScoreScript.StartGame();
        //    }

        //}

        //// Button in Final Stats Screen --> starts new Round
        //if (e.target.name == "NewGame")
        //{
        //    ScoreScript.newGame();
        //}

        //// Button on "UI CoW New MainRoom" --> changes CT to alternative Version and back
        //if (e.target.name == "Invert")
        //{
        //    CameraScript.changeView();
        //}

        //// Button on "UI CoW New MainRoom" --> changes active status of Reference Arrows on skull
        //if (e.target.name == "ChangeRef")
        //{
        //    CameraScript.changeRef();
        //    ScoreScript.changeRef();
        //}
        

        if (e.target.name == "Sphere1")
        {
            if (Sphere1)
            {
                Debug.Log("1 was clicked");
            }

        }

        if (e.target.name == "Sphere2")
        {
            if (Sphere2)
            {
                Debug.Log("1 was clicked");
            }

        }

        if (e.target.name == "Sphere3")
        {
            if (Sphere3)
            {
                Debug.Log("1 was clicked");
            }

        }

        if (e.target.name == "Sphere4")
        {
            if (Sphere4)
            {
                Debug.Log("1 was clicked");
            }

        }

        if (e.target.name == "Sphere5")
        {
            if (Sphere5)
            {
                Debug.Log("1 was clicked");
            }

        }

        if (e.target.name == "Sphere6")
        {
            if (Sphere6)
            {
                Debug.Log("1 was clicked");
            }

        }

        if (e.target.name == "Sphere7")
        {
            if (Sphere7)
            {
                Debug.Log("1 was clicked");
            }

        }

        if (e.target.name == "Sphere8")
        {
            if (Sphere8)
            {
                Debug.Log("1 was clicked");
            }

        }

        if (e.target.name == "Sphere9")
        {
            if (Sphere9)
            {
                Debug.Log("1 was clicked");
            }

        }

        if (e.target.name == "Sphere10")
        {
            if (Sphere10)
            {
                Debug.Log("1 was clicked");
            }

        }

        if (e.target.name == "Sphere11")
        {
            if (Sphere10)
            {
                Debug.Log("1 was clicked");
            }

        }

        if (e.target.name == "Sphere12")
        {
            if (Sphere10)
            {
                Debug.Log("1 was clicked");
            }

        }

        if (e.target.name == "Sphere13")
        {
            if (Sphere10)
            {
                Debug.Log("1 was clicked");
            }

        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        /*

        //This Part changes the color of the objects if a pointer entered the bounding area 
        if (e.target.name == "Sphere1")
        {  //change color of GameObject Sphere1
            Sphere1.GetComponent<Renderer>().material.color = new Color32(92, 248, 227, 203);
            //change color of laserpointer
            Pointer.color = new Color32(150, 150, 150, 255);
        }

        if (e.target.name == "Sphere2")
        {
            Sphere2.GetComponent<Renderer>().material.color = new Color32(92, 248, 227, 203);
            Pointer.color = new Color32(150, 150, 150, 255);
        }

        if (e.target.name == "Sphere3")
        {
            Sphere3.GetComponent<Renderer>().material.color = new Color32(92, 248, 227, 203);
            Pointer.color = new Color32(150, 150, 150, 255);
        }

        if (e.target.name == "Sphere4")
        {
            Sphere4.GetComponent<Renderer>().material.color = new Color32(92, 248, 227, 203);
            Pointer.color = new Color32(150, 150, 150, 255);
        }

        if (e.target.name == "Sphere5")
        {
            Sphere5.GetComponent<Renderer>().material.color = new Color32(92, 248, 227, 203);
            Pointer.color = new Color32(150, 150, 150, 255);
        }

        if (e.target.name == "Sphere6")
        {
            Sphere6.GetComponent<Renderer>().material.color = new Color32(92, 248, 227, 203);
            Pointer.color = new Color32(150, 150, 150, 255);
        }

        if (e.target.name == "Sphere7")
        {
            Sphere7.GetComponent<Renderer>().material.color = new Color32(92, 248, 227, 203);
            Pointer.color = new Color32(150, 150, 150, 255);
        }

        if (e.target.name == "Sphere8")
        {
            Sphere8.GetComponent<Renderer>().material.color = new Color32(92, 248, 227, 203);
            Pointer.color = new Color32(150, 150, 150, 255);
        }

        if (e.target.name == "Sphere9")
        {
            Sphere9.GetComponent<Renderer>().material.color = new Color32(92, 248, 227, 203);
            Pointer.color = new Color32(150, 150, 150, 255);
        }

        if (e.target.name == "Sphere10")
        {
            Sphere10.GetComponent<Renderer>().material.color = new Color32(92, 248, 227, 203);
            Pointer.color = new Color32(150, 150, 150, 255);
        }
        */
        /*
        if (e.target.name == "Next")
        {
            Pointer.color = new Color32(150, 150, 150, 255);
        }

        if (e.target.name == "Skip")
        {
            Pointer.color = new Color32(150, 150, 150, 255);
        }

        if (e.target.name == "Next2")
        {
            Pointer.color = new Color32(150, 150, 150, 255);
        }

        if (e.target.name == "Start")
        {
            Pointer.color = new Color32(150, 150, 150, 255);
        }

        if (e.target.name == "NewGame")
        {
            Pointer.color = new Color32(150, 150, 150, 255);
        }
        */
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {/*
        //This Part changes the color of the objects if a pointer left the bounding area
        if (e.target.name == "Sphere1")
        {
            Sphere1.GetComponent<Renderer>().material.color = new Color32(61, 229, 117, 203);
            Pointer.color = new Color32(0, 0, 0, 255);
        }

        if (e.target.name == "Sphere2")
        {
            Sphere2.GetComponent<Renderer>().material.color = new Color32(61, 229, 117, 203);
            Pointer.color = new Color32(0, 0, 0, 255);
        }

        if (e.target.name == "Sphere3")
        {
            Sphere3.GetComponent<Renderer>().material.color = new Color32(61, 229, 117, 203);
            Pointer.color = new Color32(0, 0, 0, 255);
        }

        if (e.target.name == "Sphere4")
        {
            Sphere4.GetComponent<Renderer>().material.color = new Color32(61, 229, 117, 203);
            Pointer.color = new Color32(0, 0, 0, 255);
        }

        if (e.target.name == "Sphere5")
        {
            Sphere5.GetComponent<Renderer>().material.color = new Color32(61, 229, 117, 203);
            Pointer.color = new Color32(0, 0, 0, 255);
        }

        if (e.target.name == "Sphere6")
        {
            Sphere6.GetComponent<Renderer>().material.color = new Color32(61, 229, 117, 203);
            Pointer.color = new Color32(0, 0, 0, 255);
        }

        if (e.target.name == "Sphere7")
        {
            Sphere7.GetComponent<Renderer>().material.color = new Color32(61, 229, 117, 203);
            Pointer.color = new Color32(0, 0, 0, 255);
        }

        if (e.target.name == "Sphere8")
        {
            Sphere8.GetComponent<Renderer>().material.color = new Color32(61, 229, 117, 203);
            Pointer.color = new Color32(0, 0, 0, 255);
        }

        if (e.target.name == "Sphere9")
        {
            Sphere9.GetComponent<Renderer>().material.color = new Color32(61, 229, 117, 203);
            Pointer.color = new Color32(0, 0, 0, 255);
        }

        if (e.target.name == "Sphere10")
        {
            Sphere10.GetComponent<Renderer>().material.color = new Color32(61, 229, 117, 203);
            Pointer.color = new Color32(0, 0, 0, 255);
        }
        */
        /*
        if (e.target.name == "Next")
        {
            Pointer.color = new Color32(0, 0, 0, 255);
        }

        if (e.target.name == "Skip")
        {
            Pointer.color = new Color32(0, 0, 0, 255);
        }

        if (e.target.name == "Next2")
        {
            Pointer.color = new Color32(0, 0, 0, 255);
        }

        if (e.target.name == "Start")
        {
            Pointer.color = new Color32(0, 0, 0, 255);
        }

        if (e.target.name == "NewGame")
        {
            Pointer.color = new Color32(0, 0, 0, 255);
        }
        */
    }

    // Start is called before the first frame update
    void Start()
    {
        Pointer = GameObject.FindGameObjectWithTag("TagPointer").GetComponent<SteamVR_LaserPointer>();
    }

    // Update is called once per frame
    void Update()
    {

           
    }
}
