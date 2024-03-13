using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCInputObserver : InputObserver
{
    [SerializeField] private KeyCode _menuCode;
    [SerializeField] private KeyCode _jumpCode;

    private void Update()
    {
        if (Input.GetKeyDown(_menuCode))
        {
            OnMenu?.Invoke();
        }
        else if (Input.GetKeyDown(_jumpCode))
        {
            OnJump?.Invoke();
        }

        var move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        OnMove?.Invoke(move.normalized);
    }
}
