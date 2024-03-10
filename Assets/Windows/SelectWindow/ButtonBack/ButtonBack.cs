using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBack : MonoBehaviour
{
    public event Action OnPress;

    [SerializeField] private Button _button;

    private void Awake()
    {
        _button.onClick.AddListener(() => OnPress?.Invoke());
    }
}
