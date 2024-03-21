using System;
using UnityEngine;
using UnityEngine.UI;

public class WindowDead : Window
{
    public event Action OnRestartLevel;
    public event Action OnGoMenu;

    [SerializeField] private Button _buttonRestart;
    [SerializeField] private Button _buttonMenu;
    [SerializeField] private AudioPlay _audioPlay;

    public const string WindowDeadName = "WindowDead";

    private void Awake()
    {
        WindowName = WindowDeadName;
        _buttonRestart.onClick.AddListener(() => OnRestartLevel?.Invoke());
        _buttonMenu.onClick.AddListener(() => OnGoMenu?.Invoke());
        OnOpen += OpenHandler;
    }

    private void OpenHandler()
    {
        Instantiate(_audioPlay, null).PlayOneShot(AudioPlay.AudioKeyLevelLose);
    }
}
