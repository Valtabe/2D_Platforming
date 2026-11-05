using UnityEngine;

public class Patroler : MonoBehaviour
{
    [SerializeField] private Transform[] _patrolingPoints;
    [SerializeField] private float _speed;

    private int _currentPoint = 0;

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        Vector2 currentPosition = transform.position;
        currentPosition.x = Mathf.MoveTowards(transform.position.x, _patrolingPoints[_currentPoint].position.x, _speed * Time.deltaTime);
        transform.position = currentPosition;


        if (transform.position.x == _patrolingPoints[_currentPoint].position.x)
        {
            _currentPoint = (_currentPoint + 1) % _patrolingPoints.Length;
        }
    }
}
