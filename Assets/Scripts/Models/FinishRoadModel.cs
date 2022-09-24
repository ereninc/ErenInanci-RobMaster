using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishRoadModel : ObjectModel
{
    [SerializeField] CharacterModel characterModel;
    [SerializeField] CameraController camController;
    [SerializeField] SafeModel safeModel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameStateController.Instance.ChangeState(GameStates.End);
            ScreenController.Instance.ShowScreen(2);
            characterModel.OnLevelFinish();
            camController.ChangeCamera(CameraStates.End);
            safeModel.OnFinish();
        }
    }
}