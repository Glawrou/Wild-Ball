using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundWindow : MonoBehaviour
{
    public event Action OnClick;

    [SerializeField] private float _duration = 1f;
    [SerializeField] private Color _startColor;
    [SerializeField] private bool _isClosePress = false;

    [Space]
    [SerializeField] private Image _image;
    [SerializeField] private Button _button;

    private readonly Color EmptyColor = new Color(0, 0, 0, 0);

    private void Awake()
    {
        _button.onClick.AddListener(() => OnClick?.Invoke());
    }

    public void Open()
    {
        _image.DOColor(_startColor, _duration);
        _image.raycastTarget = _isClosePress;
    }

    public void Close()
    {
        _image.DOColor(EmptyColor, _duration);
        _image.raycastTarget = false;
    }
}
