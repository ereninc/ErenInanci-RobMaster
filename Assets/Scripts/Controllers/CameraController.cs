using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : ObjectModel
{
    [SerializeField] CinemachineVirtualCamera[] virtualCameras;
    [SerializeField] CinemachineShake cinemachineShake;
    private CameraStates activeCamState;

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

    public void Shake()
    {
        cinemachineShake.Shake(3f, 0.25f);
    }
}

public enum CameraStates
{
//    Start,
    GamePlay,
    End
}