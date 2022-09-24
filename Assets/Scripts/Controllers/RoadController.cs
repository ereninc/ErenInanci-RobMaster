using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : ControllerModel
{
    [SerializeField] FinishRoadModel finishline;

    public override void Initialize()
    {
        base.Initialize();
        spawnRoad();
    }

    private void spawnRoad() 
    {
        WorldObjectDataModel roadData = LevelController.Controller.LoadedLevel.FinishRoadData;
        finishline.transform.position = roadData.Position;
        finishline.SetActivate();
    }
}