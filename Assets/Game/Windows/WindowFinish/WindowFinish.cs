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
    [SerializeField] private Transform _hader;
    [SerializeField] private GameObject _uiStarPrefab;

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

    public void Fill(int stars)
    {
        Instantiate(_audioPlay, null).PlayOneShot(AudioPlay.AudioKeyWin);
        CreateStars(stars);
    }

    public void CreateStars(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(_uiStarPrefab, _hader);
        }
    }
}
