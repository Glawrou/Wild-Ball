using DG.Tweening;
using UnityEngine;

public class ViewWindow : MonoBehaviour
{
    [SerializeField] private float _scale = 1;
    [SerializeField] private float _duration = 1;

    public void Open()
    {
        gameObject.SetActive(true);
        DOTween.Sequence()
          .Append(transform.DOPunchScale(Vector3.one * _scale, _duration))
          .SetLink(gameObject);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
