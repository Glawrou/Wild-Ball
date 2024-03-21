using System;
using UnityEngine;
using UnityEngine.UI;

public class WindowFinish : Window
{
    public event Action OnNextLevel;
    public event Action OnReloadLevel;
    public event Action OnGoMenu;

    [SerializeField] private Button _nextLevel;
    [SerializeField] private Button _reloadLevel;
    [SerializeField] private Button _goMenu;
    [SerializeField] private Text _place;

    [Header("Audio")]
    [SerializeField] private AudioPlay _audioPlay;

    public const string WindowFinishName = "WindowFinish";

    public void Awake()
    {
        WindowName = WindowFinishName;
        _nextLevel.onClick.AddListener(() => OnNextLevel?.Invoke());
        _reloadLevel.onClick.AddListener(() => OnReloadLevel?.Invoke());
        _goMenu.onClick.AddListener(() => OnGoMenu?.Invoke());
    }

    public void Fill(int place)
    {
        Instantiate(_audioPlay, null).PlayOneShot(AudioPlay.AudioKeyWin);
        _place.text = place.ToString();
    }
}
