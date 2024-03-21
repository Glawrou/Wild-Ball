using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private PlayerGravity _playerGravity;
    [SerializeField] private TriggerSurface _triggerSurface;
    [SerializeField] private PlayerSound _playerSound;

    [Space]
    [SerializeField] private float _jumpForce = 30f; 
    [SerializeField] private float _speed = 1f;

    public void MoveHandler(PlayerInputData playerInput)
    {
        if (playerInput.Jump && _triggerSurface.IsSurface)
        {
            _playerSound.PlayJump();
            _playerGravity.AddGravity(-_jumpForce);
        }

        _characterController.Move(Vetor2ToVector3(playerInput.Move) * _speed * Time.deltaTime);
    }

    private Vector3 Vetor2ToVector3(Vector2 vector)
    {
        return new Vector3(vector.x, 0, vector.y);
    }
}
