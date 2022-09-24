using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModel : ObjectModel
{
    [SerializeField] DraggableController draggableController;
    [SerializeField] float maxForwardSpeed;
    [SerializeField] float forwardSpeed;
    [SerializeField] float extraForwardSpeed;
    [SerializeField] Vector3 movePosition;

    public int State; //0->OnStart, 1->OnMoveForward, 2->OnDraggable

    public override void Initialize()
    {
        base.Initialize();
        State = 0;
    }

    public void CharacterUpdate()
    {
        switch (State)
        {
            case 0:
                //Wait in idle to start level
                break;
            case 1:
                moveForward();
                break;
            case 2:
                moveForward();
                break;
            default:
                break;
        }
    }

    public void OnDefaultPose()
    {
        draggableController.OnDefaultPose();
    }

    public void SetState(int state)
    {
        State = state;
        draggableController.OnStateChange(State);
        setSpeed(State);
    }

    public void OnLevelFinish()
    {
        OnDefaultPose();

    }

    private void moveForward()
    {
        movePosition = new Vector3(0, 0, transform.position.z + ((1 + extraForwardSpeed) * forwardSpeed * Time.deltaTime));
        transform.position = movePosition;
    }

    private void setSpeed(int state)
    {
        if (State == 0)
        {
            forwardSpeed = 0;
        }
        else if (State == 1)
        {
            forwardSpeed = 10;
        }
        else
        {
            forwardSpeed = maxForwardSpeed * 0.15f;
        }
    }
}