using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _speed;

    public void SetTarget(Player player)
    {
        _player = player;
    }

    private void Update()
    {
        if (!_player)
        {
            return;
        }

        var targetPosition = _player.transform.position + _offset;
        var speed = _speed * Vector3.Distance(transform.position, targetPosition);
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed);
    }
}
