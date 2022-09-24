using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : ObjectModel
{
    [SerializeField] CinemachineVirtualCamera[] virtualCameras;
    CameraStates activeCamState;

    public override void Initialize()
    {
        base.Initialize();
        activeCamState = CameraStates.GamePlay;
        virtualCameras[(int)activeCamState].gameObject.SetActive(true);
    }


    public void ChangeCamera(CameraStates cameraStates)
    {
        if (activeCamState == cameraStates)
        {
            return;
        }

        virtualCameras[(int)activeCamState].gameObject.SetActive(false);
        activeCamState = cameraStates;
        virtualCameras[(int)activeCamState].gameObject.SetActive(true);
    }
}

public enum CameraStates
{
//    Start,
    GamePlay,
    End
}