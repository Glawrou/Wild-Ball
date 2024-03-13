using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCInputObserver : InputObserver
{
    [SerializeField] private KeyCode _menuCode;

    private void Update()
    {
        if (Input.GetKeyDown(_menuCode))
        {
            OnPressMenu?.Invoke();
        }
    }
}
