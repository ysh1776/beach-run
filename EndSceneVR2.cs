﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneVR2 : MonoBehaviour
{
    public Valve.VR.SteamVR_Input_Sources handType;
    public Valve.VR.SteamVR_Action_Boolean grabAction;
    public Valve.VR.SteamVR_Action_Boolean clickDebug;
    public Valve.VR.SteamVR_Action_Boolean clickMenu;
    public Valve.VR.SteamVR_Action_Vibration vibration;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clickMenu.GetChanged(handType) == true)
        {
            SceneManager.LoadScene("StartScene");

            Debug.Log("1");
        }
    }
}
