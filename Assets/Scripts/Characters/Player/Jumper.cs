using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private float _jumpForce;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (_groundChecker.IsGround())
        {
            Vector2 velocity = rb.velocity;
            velocity.y = _jumpForce;

            rb.velocity = velocity;
        }
    }
}
