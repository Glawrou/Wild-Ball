using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationLevelItem : LevelItem
{
    [SerializeField] private Animator _animator;

    private const int StateNumbers = 3;
    private const string KeyAnim = "State";

    private void TriggerAnimHandler()
    {
        _animator.SetInteger(KeyAnim, Random.Range(0, StateNumbers));
    }
}
