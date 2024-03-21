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

    private int _levelsStorageCount => _levelsStorage.Count;
    private LevelResultData[] _levels;

    public void Awake()
    {
        WindowName = SelectWindowName;
    }

    private void Start()
    {
        _backgroundWindow.OnClick += () => OnBack?.Invoke();
    }

    public void Init(LevelResultData[] levels)
    {
        _levels = levels;
        Instantiate(_buttonBackPrefab, _panel)
            .OnPress += () => OnBack?.Invoke();
        for (var levelNumber = 1; levelNumber <= _levelsStorageCount; levelNumber++)
        {
            var levelButton = Instantiate(_buttonSelectPrefab, _panel);
            levelButton.OnPress += (level) => OnLevelPress?.Invoke(level);
            levelButton.Init(
                levelNumber, 
                _levels.Length < levelNumber ? null : _levels[levelNumber - 1], 
                levelNumber <= _levels.Length + 1);
        }
    }
}
