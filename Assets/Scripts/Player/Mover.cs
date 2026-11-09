using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _speed;

    private Vector2 _frontDirection = new Vector2(0, 0);
    private Vector2 _reflectionDirection = new Vector2(0, 180);

    private void OnEnable()
    {
        _inputReader.DirectionInputing += Move;
    }

    private void OnDisable()
    {
        _inputReader.DirectionInputing -= Move;
    }

    private void Move(float horizontalDirection)
    {
        Vector2 direction = new Vector2();
        direction.x = horizontalDirection;

        if (direction.x > 0)
        {
            transform.Translate(_speed * Time.deltaTime * direction);
            transform.rotation = Quaternion.Euler(_frontDirection);
        }
        else
        {
            transform.Translate(_speed * Time.deltaTime * -direction);
            transform.rotation = Quaternion.Euler(_reflectionDirection);
        }    
    }
}
