using System.Linq;
using UnityEngine;
using System;
using System.Collections.Generic;

public class Windows : MonoBehaviour
{
    [SerializeField] private bool _isOpenFirstWindow = true;

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

        if (_isOpenFirstWindow)
        {

            _windows[0].Open();
        }
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
        var window = FoundWindow(windowName);
        CloseAllExcept(window);
        window.Open();
    }

    public void Close(string windowName)
    {
        var window = FoundWindow(windowName);
        window.Close();
    }

    public void Toggle(string windowName)
    {
        var window = FoundWindow(windowName);
        CloseAllExcept(window);
        window.Toggle();
    }

    private Window FoundWindow(string windowName)
    {
        if (!_windows.Any(w => w.WindowName == windowName))
        {
            Debug.LogError($"There is no window with that name {windowName}");
            return null;
        }

        return _windows.FirstOrDefault(w => w.WindowName == windowName);
    }

    private void CloseAllExcept(Window window)
    {
        Close(_windows.Where(w => w != window).ToArray());
    }

    private void Close(Window[] windows)
    {
        foreach (var window in windows)
        {
            window.Close();
        }
    }
}
