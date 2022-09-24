using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTriggerModel : ObjectModel
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            Debug.Log("COLLIDED WITH CHARACTER BODY PART");
        }
    }
}