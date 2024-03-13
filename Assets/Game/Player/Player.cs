using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator _playerAnimator;

    private const string TriggerJump = "Jump";
    private const string TriggerMove = "Move";
    private const string BoolMove = "IsMove";

    public void Jump()
    {
        _playerAnimator.SetTrigger(TriggerJump);
    }

    public void Move(Vector2 move)
    {
        _playerAnimator.SetBool(BoolMove, move.y != 0);
        _playerAnimator.SetFloat(TriggerMove, move.y);
    }
}
