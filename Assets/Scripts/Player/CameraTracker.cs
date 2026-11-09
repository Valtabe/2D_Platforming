using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _xOffset;

    private void LateUpdate()
    {
        Vector3 position = transform.position;
        position.x = _player.transform.position.x + _xOffset;
        transform.position = position;
    }
}