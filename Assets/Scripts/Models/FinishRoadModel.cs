using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishRoadModel : ObjectModel
{
    [SerializeField] CharacterModel characterModel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameStateController.Instance.ChangeState(GameStates.End);
            ScreenController.Instance.ShowScreen(2);
            //characterModel.OnLevelFinish();
        }
    }
}
