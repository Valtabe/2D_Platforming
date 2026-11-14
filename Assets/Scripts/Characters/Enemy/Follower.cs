using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _frontDirection = new Vector2(0, 0);
    private Vector2 _reflectionDirection = new Vector2(0, 180);

    public void Follow(Player target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, _speed * Time.deltaTime);

        if (target.transform.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(_frontDirection);
        }
        else
        {
            transform.rotation = Quaternion.Euler(_reflectionDirection);
        }
    }
}
