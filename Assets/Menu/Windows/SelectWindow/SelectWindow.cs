using System;
using UnityEngine;

public class SelectWindow : Window
{
    public event Action OnBack;
    public event Action<int> OnLevelPress;

    public const string SelectWindowName = "Levels";

    [SerializeField] private Transform _panel;

    [Header("Prefabs")]
    [SerializeField] private ButtonBack _buttonBackPrefab;
    [SerializeField] private ButtonLevelSelect _buttonSelectPrefab;
    [SerializeField] private LevelsStorage _levelsStorage;

    private int _levels => _levelsStorage.Count;

    public void Awake()
    {
        WindowName = SelectWindowName;
        Instantiate(_buttonBackPrefab, _panel)
            .OnPress += () => OnBack?.Invoke();
        for (var levelNumber = 1; levelNumber <= _levels; levelNumber++)
        {
            var levelButton = Instantiate(_buttonSelectPrefab, _panel);
            levelButton.OnPress += (level) => OnLevelPress?.Invoke(level);
            levelButton.Init(levelNumber);
        }
    }

    private void Start()
    {
        _backgroundWindow.OnClick += () => OnBack?.Invoke();
    }
}
