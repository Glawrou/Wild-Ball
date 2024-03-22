using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : SceneController
{
    [SerializeField] private InputObserver[] _inputObserver;

    [Space]
    [SerializeField] private LevelsStorage _levelsStorage;
    [SerializeField] private GameCamera _gameCamera;

    [Header("Windows")]
    [SerializeField] private Windows _windows;
    [SerializeField] private WindowFinish _windowFinish;
    [SerializeField] private WindowPauseMenu _pauseMenuWindow;
    [SerializeField] private WindowDead _windowDead;

    private GameSceneParams _sceneParams => SceneParams as GameSceneParams;

    private new void Awake()
    {
        base.Awake();
        if (SceneParams == null)
        {
            SceneParams = new GameSceneParams(1);
        }
    }

    private void Start()
    {
        InitWindows();
        InitInputObserver();
        InitPauseMenu();
        InitFinishGame();
        InitWindowDead();
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
        _windowFinish.OnNextLevel += LoadNextLevel;
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
        var level = _levelsStorage.Init(_sceneParams.LevelNumber, _gameCamera, _inputObserver);
        level.OnDead += () => _windows.Open(_windowDead.WindowName);
        level.OnFinish += FinishHandler;
    }

    private void LoadNextLevel()
    {
        var maxLevel = _levelsStorage.Count + 1;
        var nextLevel = _sceneParams.LevelNumber + 1;
        if (nextLevel >= maxLevel)
        {
            LoadScene(new MenuSceneParams());
            return;
        }

        LoadSceneForTransite(new GameSceneParams(nextLevel));
    }

    private void FinishHandler(int stars)
    {
        AddResultLevel(_sceneParams.LevelNumber, stars);
        _windowFinish.Fill(stars);
        _windows.Open(_windowFinish.WindowName);
    }
}
