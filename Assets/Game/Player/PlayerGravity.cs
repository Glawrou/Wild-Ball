using UnityEngine;

public class PlayerGravity : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private TriggerSurface _triggerSurface;
    [SerializeField] private float _gravityForce = -0.1f;
    [SerializeField] private float _gravityForceForTime = 1;

    private float _currentGravityForce = 0;

    private void Awake()
    {
        _currentGravityForce = _gravityForce;
    }

    public void AddGravity(float gravity)
    {
        _currentGravityForce += gravity;
    }

    private void Update()
    {
        CalculateGravity();
        _characterController.Move(-Vector3.up * _currentGravityForce * Time.deltaTime);
    }

    private void CalculateGravity()
    {
        if (!_triggerSurface.IsSurface)
        {
            _currentGravityForce += Time.timeScale * _gravityForceForTime;
        }
        else
        {
            _currentGravityForce = Mathf.Clamp(_currentGravityForce, float.MinValue, _gravityForce);
        }
    }
}
