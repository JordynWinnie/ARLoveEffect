using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class AutoFocusCamera : MonoBehaviour
{
    private bool m_vuforiaStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        var vuforia = VuforiaARController.Instance;
        if (vuforia != null)
        {
            vuforia.RegisterVuforiaStartedCallback(InitCameraFocus);
        }
    }

    private void InitCameraFocus()
    {
        m_vuforiaStarted = true;
        SetAutoFocus();
    }

    private void SetAutoFocus()
    {
        Debug.Log(CameraDevice.Instance.SetFocusMode(
            CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO)
            ? "Success in setting the camera to autofocus continuously."
            : "Failed to set the camera to autofocus continuously.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            // since the app has resumed we will start autofocus.
            SetAutoFocus();
        }
    }

}
