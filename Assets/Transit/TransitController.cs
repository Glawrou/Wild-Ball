using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TransitController : SceneController
{
    [Space]
    [SerializeField] private Button _buttonContinue;
    [SerializeField] private Image _imageContinue;

    private TransitSceneParams _sceneParams => SceneParams as TransitSceneParams;
    private const float Delay = 1f;

    private new void Awake()
    {
        base.Awake();
        _buttonContinue.onClick.AddListener(ClickContinueHandler);
        if (SceneParams == null)
        {
            SceneParams = new TransitSceneParams(new MenuSceneParams());
        }
    }

    private void Start()
    {
        StartCoroutine(Init());
    }

    private IEnumerator Init()
    {
        Music.Instance.Pause();
        _buttonContinue.interactable = false;
        for (var i = 0f; i < Delay; i += Time.deltaTime)
        {
            yield return null;
            _imageContinue.fillAmount = i / Delay;
        }

        _imageContinue.fillAmount = 1;
        _buttonContinue.interactable = true;
    }

    private void ClickContinueHandler()
    {
        Music.Instance.Play();
        LoadScene(_sceneParams.NextScene);
    }
}
