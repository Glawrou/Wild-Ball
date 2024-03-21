using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPlay : MonoBehaviour
{
    [SerializeField] private AudioPlay _audioPlayPrefab;
    [SerializeField] private Button _button;
    [SerializeField] private AudioClip _audio;

    private void Awake()
    {
        _button.onClick.AddListener(ClickHandler);
    }

    private void ClickHandler()
    {
        var audio = Instantiate(_audioPlayPrefab, Vector3.zero, Quaternion.identity, null);
        audio.PlayOneShot(_audio);
    }
}
