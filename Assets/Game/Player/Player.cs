using UnityEngine;

public class Player : MonoBehaviour
{
    public const string PlayerTag = "Player";

    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private PlayerAnimation _playerAnimation;

    private InputObserver[] _inputObserver;

    public void Init(InputObserver[] inputObservers)
    {
        _inputObserver = inputObservers;
        foreach (var obs in _inputObserver)
        {
            obs.OnPlayer += _playerMove.MoveHandler;
            obs.OnPlayer += _playerAnimation.AnimHandler;
        }
    }

    public void Dead()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        foreach (var obs in _inputObserver)
        {
            obs.OnPlayer -= _playerMove.MoveHandler;
            obs.OnPlayer -= _playerAnimation.AnimHandler;
        }
    }
}
