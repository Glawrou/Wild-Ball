using System;
using UnityEngine;
using UnityEngine.UI;

public class WindowPauseMenu : Window
{
    public event Action OnPressMenu;
    public event Action OnResume;

    [SerializeField] private Button _menuButton;
    [SerializeField] private Button _resumeButton;

    public const string PauseMenuWindowName = "PauseMenu";

    private void Awake()
    {
        WindowName = PauseMenuWindowName;
        OnOpen += PauseGame;
        OnClose += ResumeGame;
        _resumeButton?.onClick.AddListener(() => OnResume?.Invoke());
        _menuButton?.onClick.AddListener(() => OnPressMenu?.Invoke());
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
