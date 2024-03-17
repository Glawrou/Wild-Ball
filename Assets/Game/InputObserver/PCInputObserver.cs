using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCInputObserver : InputObserver
{
    [SerializeField] private KeyCode _menuCode;

    private const string KeyMoveHorizontal = "Horizontal";
    private const string KeyMoveVertical = "Vertical";
    private const string KeyJump = "Jump";

    private void Update()
    {
        if (Input.GetKeyDown(_menuCode))
        {
            OnMenu?.Invoke();
        }

        var playerInput = new PlayerInputData(
            Input.GetAxis(KeyMoveHorizontal), 
            Input.GetAxis(KeyMoveVertical),
            Input.GetButtonDown(KeyJump));

        OnPlayer?.Invoke(playerInput);
    }
}
