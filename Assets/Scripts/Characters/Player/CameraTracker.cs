using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _xOffset;

    private bool _isPlayerAlive;

    private void OnEnable()
    {
        _player.Died += StayStatic;
    }

    private void OnDisable()
    {
        _player.Died -= StayStatic;
    }

    private void Start()
    {
        _isPlayerAlive = true;
    }

    private void LateUpdate()
    {
        if (_isPlayerAlive)
        {
            Vector3 position = transform.position;
            position.x = _player.transform.position.x + _xOffset;
            transform.position = position;
        }
    }

    private void StayStatic()
    {
        _isPlayerAlive = false;
    }
}