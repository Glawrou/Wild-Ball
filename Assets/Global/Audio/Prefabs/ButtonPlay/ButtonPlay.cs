using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPlay : MonoBehaviour
{
    [SerializeField] private AudioPlay _audioPlayPrefab;
    [SerializeField] private Button _button;

    private void Awake()
    {
        _button.onClick.AddListener(ClickHandler);
    }

    private void ClickHandler()
    {
        Instantiate(_audioPlayPrefab, null).PlayOneShot(AudioPlay.AudioKeyClick);
    }
}
