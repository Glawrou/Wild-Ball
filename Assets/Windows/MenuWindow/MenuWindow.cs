using System;
using UnityEngine;
using UnityEngine.UI;

public class MenuWindow : Window
{
    public event Action OnPressPlay;
    public event Action OnPressSettings;
    public event Action OnPressExit;

    public const string MenuWindowName = "Menu";

    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _exitButton;

    private void Awake()
    {
        WindowName = MenuWindowName;
        _playButton.onClick.AddListener(() => OnPressPlay?.Invoke());
        _settingsButton.onClick.AddListener(() => OnPressSettings?.Invoke());
        _exitButton.onClick.AddListener(() => OnPressExit?.Invoke());
    }
}
