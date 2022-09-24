using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailEffect : ObjectModel
{
    [SerializeField] Animator animator;

    public void Show() 
    {
        animator.Play("FailEffect", 0, 0);
    }
}