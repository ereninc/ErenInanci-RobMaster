using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeModel : ObjectModel
{
    [SerializeField] Animator animator;

    public void OnFinish()
    {
        animator.Play("OnOpen", 0, 0);
    }
}