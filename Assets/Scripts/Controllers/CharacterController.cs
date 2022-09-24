using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : ControllerModel
{
    [SerializeField] CharacterModel characterModel;
    public override void ControllerUpdate()
    {
        base.ControllerUpdate();
        if (GameStateController.CurrentState == GameStates.Game)
        {
            characterUpdate();
        }
    }

    private void characterUpdate() 
    {
        characterModel.CharacterUpdate();
    }
}