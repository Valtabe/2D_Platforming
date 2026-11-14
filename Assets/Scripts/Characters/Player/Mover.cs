using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _frontDirection = new Vector2(0, 0);
    private Vector2 _reflectionDirection = new Vector2(0, 180);

    public void Move(float horizontalDirection)
    {
        if (horizontalDirection > 0)
        {
            transform.Translate(_speed * Time.deltaTime * new Vector2(horizontalDirection, 0));
            transform.rotation = Quaternion.Euler(_frontDirection);
        }
        else
        {
            transform.Translate(_speed * Time.deltaTime * new Vector2(-horizontalDirection, 0));
            transform.rotation = Quaternion.Euler(_reflectionDirection);
        }    
    }
}
