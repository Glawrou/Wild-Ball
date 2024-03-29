using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class InputObserver : MonoBehaviour
{
    public Action OnMenu;
    public Action<PlayerInputData> OnPlayer;
}
