using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : LevelItem
{
    [SerializeField] private Animator _animator;

    private string TriggerOpen = "Open";

    public void Use()
    {
        _animator.SetTrigger(TriggerOpen);
    }
}
