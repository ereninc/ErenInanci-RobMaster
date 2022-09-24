using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleModel : ObjectModel
{
    [SerializeField] CharacterModel character;
    public int Id;

    public override void Initialize()
    {
        base.Initialize();
        SetActivate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            character = other.GetComponent<CharacterModel>();
            character.SetState(2);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            character.SetState(1);
        }
    }
}