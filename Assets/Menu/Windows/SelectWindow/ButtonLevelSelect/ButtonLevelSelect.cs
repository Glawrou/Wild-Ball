using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLevelSelect : MonoBehaviour
{
    public event Action<int> OnPress;

    [SerializeField] private Text _levelNumberText;
    [SerializeField] private Button _button;
    [SerializeField] private Transform _stars;
    [SerializeField] private GameObject _uiStarPrefab;

    private int _levelNumber = 0;

    public void Init(int levelNumber, LevelResultData resultData, bool active)
    {
        _levelNumber = levelNumber;
        _levelNumberText.text = _levelNumber.ToString();
        _button.onClick.AddListener(() => OnPress?.Invoke(_levelNumber));
        _button.interactable = active;
        if (resultData == null)
        {
            return;
        }

        for (var i = 0; i < resultData.Stars; i++)
        {
            Instantiate(_uiStarPrefab, _stars);
        }
    }
}
