using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : UseLevelItem
{
    [SerializeField] private Animator _animator;

    private string TriggerOpen = "Open";

    public override void Use()
    {
        _animator.SetTrigger(TriggerOpen);
    }
}
