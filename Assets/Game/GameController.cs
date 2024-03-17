using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : SceneController
{
    [SerializeField] private InputObserver[] _inputObserver;

    [Space]
    [SerializeField] private Level _level;
    [SerializeField] private GameCamera _gameCamera;

    [Header("Windows")]
    [SerializeField] private Windows _windows;
    [SerializeField] private WindowFinish _windowFinish;
    [SerializeField] private WindowPauseMenu _pauseMenuWindow;
    [SerializeField] private WindowDead _windowDead;

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
        InitFinishGame();
        InitWindowDead();
        Debug.Log($"Load level {_sceneParams.LevelNumber}");
        InitGame();
    }

    private void InitWindows()
    {
        _windows.Init(new Window[] { _pauseMenuWindow, _windowFinish, _windowDead });
    }

    private void InitInputObserver()
    {
        foreach (var item in _inputObserver)
        {
            item.OnMenu += () => _windows.Toggle(_pauseMenuWindow.WindowName);
        }
    }

    private void InitPauseMenu()
    {
        _pauseMenuWindow.OnPressMenu += () => LoadScene(new MenuSceneParams());
        _pauseMenuWindow.OnResume += () => _windows.Close(_pauseMenuWindow.WindowName);
    }

    private void InitFinishGame()
    {
        _windowFinish.OnNextLevel += () => LoadScene(new GameSceneParams(_sceneParams.LevelNumber + 1));
        _windowFinish.OnReloadLevel += ReloadScene;
        _windowFinish.OnGoMenu += () => LoadScene(new MenuSceneParams());
    }

    private void InitWindowDead()
    {
        _windowDead.OnRestartLevel += ReloadScene;
        _windowDead.OnGoMenu += () => LoadScene(new MenuSceneParams());
    }

    private void InitGame()
    {
        _level.OnDead += () => _windows.Open(_windowDead.WindowName);
        _level.OnFinish += (count) => _windowFinish.Fill(count);
        _level.OnFinish += (count) => _windows.Open(_windowFinish.WindowName);
        _level.Init(_gameCamera, _inputObserver);
    }
}
