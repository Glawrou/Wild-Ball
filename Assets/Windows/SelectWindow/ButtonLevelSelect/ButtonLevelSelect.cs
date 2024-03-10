using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLevelSelect : MonoBehaviour
{
    public event Action<int> OnPress;

    [SerializeField] private Text _levelNumberText;
    [SerializeField] private Button _button;

    private int _levelNumber = 0;

    public void Init(int levelNumber)
    {
        _levelNumber = levelNumber;
        _levelNumberText.text = _levelNumber.ToString();
        _button.onClick.AddListener(() => OnPress?.Invoke(_levelNumber));
    }
}
