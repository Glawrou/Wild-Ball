using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private TriggerSurface _triggerSurface;

    private const string KeyAnimJump = "Jump";
    private const string KeyAnimWalk = "Walk";
    private const string KeyAnimSpeed = "Speed";

    private void Awake()
    {
        _triggerSurface.OnSurfaceChange += SurfaceChangeHandler;
    }

    public void AnimHandler(PlayerInputData playerInput)
    {
        _animator.SetBool(KeyAnimWalk, playerInput.Move.x != 0 || playerInput.Move.y != 0);
        RotateTowards(playerInput.Move);
    }

    private void SurfaceChangeHandler(bool value)
    {
        _animator.SetBool(KeyAnimJump, !value);
    }

    public void RotateTowards(Vector2 direction)
    {
        if (direction == Vector2.zero)
        {
            return;
        }

        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle = -Mathf.RoundToInt(angle);
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
