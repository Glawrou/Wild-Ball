using System;
using UnityEngine;
using System.Linq;

public class TriggerSurface : MonoBehaviour
{
    public event Action<bool> OnSurfaceChange;
    public bool IsSurface { get; private set; }

    [SerializeField] private CharacterController _characterController;

    private void Update()
    {
        SetSurface(_characterController.isGrounded);
    }

    public void SetSurface(bool value)
    {
        if (IsSurface == value)
        {
            return;
        }

        IsSurface = value;
        OnSurfaceChange?.Invoke(IsSurface);
    }
}
