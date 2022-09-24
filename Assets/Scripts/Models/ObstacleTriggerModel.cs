using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTriggerModel : ObjectModel
{
    [SerializeField] FailEffect failEffect;
    [SerializeField] CameraController cameraController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            failEffect.Show();
            cameraController.Shake();
        }
    }
}