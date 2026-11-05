using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        _inputReader.DirectionInputing += Move;
    }

    private void OnDisable()
    {
        _inputReader.DirectionInputing -= Move;
    }

    private void Update()
    {
        _animator.SetBool("isRunning", _inputReader.IsHorizontalInput);
    }

    private void Move(float horizontalDirection)
    {
        Vector2 direction = new Vector2();
        direction.x = horizontalDirection;

        if (direction.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }    

        transform.Translate(_speed * Time.deltaTime * direction);
    }
}
