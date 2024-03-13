using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : SceneController
{
    [SerializeField] private InputObserver _inputObserver;

    [Header("Windows")]
    [SerializeField] private Windows _windows;
    [SerializeField] private PauseMenuWindow _pauseMenuWindow;

    private void Start()
    {
        InitWindows();
        InitInputObserver();
        InitPauseMenu();
    }

    private void InitWindows()
    {
        _windows.Init(new Window[] { _pauseMenuWindow });
    }

    private void InitInputObserver()
    {
        _inputObserver.OnPressMenu += () => _windows.Toggle(_pauseMenuWindow.WindowName);
    }

    private void InitPauseMenu()
    {
        _pauseMenuWindow.OnPressMenu += () => LoadScene("Menu");
        _pauseMenuWindow.OnResume += () => _windows.Close(_pauseMenuWindow.WindowName);
    }
}
