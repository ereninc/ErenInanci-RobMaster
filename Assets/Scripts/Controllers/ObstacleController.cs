using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : ControllerModel
{
    [SerializeField] MultiplePoolModel obstaclePools;
    [SerializeField] LevelModel activeLevel;

    public override void Initialize()
    {
        base.Initialize();
        activeLevel = LevelController.Controller.LoadedLevel;
        spawnObstacles();
    }

    private void spawnObstacles()
    {
        for (int i = 0; i < activeLevel.ObstacleDatas.Length; i++)
        {
            ObstacleDataModel obstacleData = activeLevel.ObstacleDatas[i];
            ObstacleModel obstacle = obstaclePools.Pools[obstacleData.Id].GetDeactiveItem<ObstacleModel>();
            obstacle.Id = obstacleData.Id;
            obstacle.transform.position = obstacleData.Position;
            obstacle.Initialize();
        }
    }
}