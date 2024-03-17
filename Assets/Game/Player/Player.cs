using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputObserver[] _inputObserver;
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private PlayerAnimation _playerAnimation;

    private void Start()
    {
        foreach (var obs in _inputObserver)
        {
            obs.OnPlayer += _playerMove.MoveHandler;
            obs.OnPlayer += _playerAnimation.AnimHandler;
        }
    }
}
