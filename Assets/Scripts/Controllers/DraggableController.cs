using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableController : ControllerModel
{
    [SerializeField] DraggableModel[] draggables;
    [SerializeField] Transform[] targetPoints;
    [SerializeField] Transform[] followPoints;
    [SerializeField] Vector3 followOffset;

    public override void ControllerUpdate()
    {
        base.ControllerUpdate();
        if (GameStateController.CurrentState == GameStates.Game)
        {
            followTargetPoints();
        }
    }

    private void followTargetPoints()
    {
        for (int i = 0; i < draggables.Length; i++)
        {
            targetPoints[i].transform.position = followPoints[i].transform.position;
        }

        for (int i = 0; i < followPoints.Length; i++)
        {
            followPoints[i].transform.position = draggables[i].transform.position + followOffset;
        }
    }
}