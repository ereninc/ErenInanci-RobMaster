using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleModel : ObjectModel
{
    public int Id;

    public override void Initialize()
    {
        base.Initialize();
        SetActivate();
    }
}