using System.Linq;
using UnityEngine;
using System;
using System.Collections.Generic;

public class Windows : MonoBehaviour
{
    private List<Window> _windows;

    public void Init(Window[] windows)
    {
        foreach (var window in windows)
        {
            AddWindow(window);
        }

        foreach (var window in _windows)
        {
            window.Close();
        }

        _windows[0].Open();
    }

    public void AddWindow(Window window)
    {
        if (_windows == null)
        {
            _windows = new List<Window>();
        }

        _windows.Add(window);
    }

    public void Open(string windowName)
    {
        if (!_windows.Any(w => w.WindowName == windowName))
        {
            Debug.LogError($"There is no window with that name {windowName}");
            return;
        }

        foreach (var window in _windows)
        {
            window.Close();
        }

        _windows.FirstOrDefault(w => w.WindowName == windowName).Open();
    }
}
