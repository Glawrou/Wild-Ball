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
        DOTween.Sequence()
          .Append(_image.DOColor(_startColor, _duration))
          .SetLink(gameObject);
        _image.raycastTarget = _isClosePress;
    }

    public void Close()
    {
        DOTween.Sequence()
          .Append(_image.DOColor(EmptyColor, _duration))
          .SetLink(gameObject);
        _image.raycastTarget = false;
    }
}
