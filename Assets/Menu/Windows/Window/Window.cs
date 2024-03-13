using System;
using UnityEngine;

public class Window : MonoBehaviour
{
    public event Action OnOpen;
    public event Action OnClose;

    public string WindowName { get; protected set; }

    [SerializeField] protected BackgroundWindow _backgroundWindow;
    [SerializeField] private ViewWindow _viewWindow;

    private bool _isOpen = false;

    public void Open()
    {
        _viewWindow.Open();
        _backgroundWindow.Open();
        _isOpen = true;
        OnOpen?.Invoke();
    }

    public void Close()
    {
        _viewWindow.Close();
        _backgroundWindow.Close();
        _isOpen = false;
        OnClose?.Invoke();
    }

    public void Toggle()
    {
        if (_isOpen)
        {
            Close();
            return;
        }

        Open();
    }
}
