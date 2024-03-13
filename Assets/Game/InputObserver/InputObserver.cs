using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class InputObserver : MonoBehaviour
{
    public Action OnMenu;
    public Action<Vector2> OnMove;
    public Action OnJump;
}
