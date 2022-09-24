using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;

public class DraggableController : ControllerModel
{
    [SerializeField] DraggableModel[] draggables;
    [SerializeField] Transform[] targetPoints;
    [SerializeField] Transform[] followPoints;
    [SerializeField] Vector3 followOffset;
    [SerializeField] Vector3[] defaultPos;

    public override void ControllerUpdate()
    {
        base.ControllerUpdate();
        if (GameStateController.CurrentState == GameStates.Game)
        {
            followTargetPoints();
        }
    }

    public void OnDefaultPose()
    {
        for (int i = 0; i < draggables.Length; i++)
        {
            draggables[i].transform.DOLocalMove(defaultPos[i], 0.25f);
        }
    }

    public void OnStateChange(int state) 
    {
        switch (state)
        {
            case 0:
                break;
            case 1:
                onMoveState();
                break;
            case 2:
                onDraggableState();
                break;
            default:
                break;
        }
    }

    private void onMoveState() 
    {
        OnDefaultPose();
        foreach (var item in draggables)
        {
            item.gameObject.SetActive(false);
        }
    }

    private void onDraggableState()
    {
        foreach (var item in draggables)
        {
            item.gameObject.SetActive(true);
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

#if UNITY_EDITOR
[CustomEditor(typeof(DraggableController))]
public class DraggableControlEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Get Items"))
        {
            ((DraggableController)target).OnDefaultPose();
        }
    }
}
#endif