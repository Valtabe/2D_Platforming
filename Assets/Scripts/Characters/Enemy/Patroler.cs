using UnityEngine;

public class Patroler : MonoBehaviour
{
    [SerializeField] private Transform[] _patrolingPoints;
    [SerializeField] private float _speed;

    private Vector2 _frontDirection = new Vector2(0, 0);
    private Vector2 _reflectionDirection = new Vector2(0, 180);

    private int _currentPoint = 0;

    private void Start()
    {
        if (_patrolingPoints[0].position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(_frontDirection);
        }
        else
        {
            transform.rotation = Quaternion.Euler(_reflectionDirection);
        }
    }

    public void Patrol()
    {
        Vector2 currentPosition = transform.position;
        currentPosition.x = Mathf.MoveTowards(transform.position.x, _patrolingPoints[_currentPoint].position.x, _speed * Time.deltaTime);
        transform.position = currentPosition;

        if (transform.position.x == _patrolingPoints[_currentPoint].position.x)
        {
            _currentPoint = (_currentPoint + 1) % _patrolingPoints.Length;

            if (_patrolingPoints[_currentPoint].position.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(_frontDirection);
            }
            else
            {
                transform.rotation = Quaternion.Euler(_reflectionDirection);
            }
        }
    }
}
