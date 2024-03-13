using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : SceneController
{
    [SerializeField] private InputObserver _inputObserver;
    [SerializeField] private Player _player;

    [Header("Windows")]
    [SerializeField] private Windows _windows;
    [SerializeField] private PauseMenuWindow _pauseMenuWindow;

    private GameSceneParams _sceneParams => SceneParams as GameSceneParams;

    private void Awake()
    {
        if (SceneParams == null)
        {
            SceneParams = new GameSceneParams(0);
        }
    }

    private void Start()
    {
        InitWindows();
        InitInputObserver();
        InitPauseMenu();
        Debug.Log($"Load level {_sceneParams.LevelNumber}");
    }

    private void InitWindows()
    {
        _windows.Init(new Window[] { _pauseMenuWindow });
    }

    private void InitInputObserver()
    {
        _inputObserver.OnMenu += () => _windows.Toggle(_pauseMenuWindow.WindowName);
        _inputObserver.OnJump += _player.Jump;
        _inputObserver.OnMove += _player.Move;
    }

    private void InitPauseMenu()
    {
        _pauseMenuWindow.OnPressMenu += () => LoadScene(new MenuSceneParams());
        _pauseMenuWindow.OnResume += () => _windows.Close(_pauseMenuWindow.WindowName);
    }
}
