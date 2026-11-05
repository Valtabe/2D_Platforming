using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private float _jumpForce;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _inputReader.JumpInputing += Jump;
    }

    private void OnDisable()
    {
        _inputReader.JumpInputing -= Jump;
    }

    private void Jump()
    {
        if (_groundChecker.IsGround())
        {
            Vector2 velocity = rb.velocity;
            velocity.y = _jumpForce;

            rb.velocity = velocity;
        }
    }
}
