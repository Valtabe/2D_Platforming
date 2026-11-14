using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private readonly string _horizontal = "Horizontal";
    private readonly KeyCode _jumpButton = KeyCode.Space;
    private readonly KeyCode _attackButton = KeyCode.F;    

    public event Action<float> DirectionInputing;
    public event Action<bool> DirectionButtonStateChange;
    public event Action JumpInputing;
    public event Action AttackInputing;

    private bool _isHorizontalInput = false;

    private void Start()
    {
        _isHorizontalInput = false;
    }

    private void Update()
    {
        if (Input.GetAxis(_horizontal) != 0)
        {
            DirectionInputing?.Invoke(Input.GetAxis(_horizontal));

            if (_isHorizontalInput == false)
            {
                _isHorizontalInput = true;
                DirectionButtonStateChange(_isHorizontalInput);
            }
        }
        else if (_isHorizontalInput)
        {
            _isHorizontalInput = false;
            DirectionButtonStateChange(_isHorizontalInput);
        }

        if (Input.GetKeyDown(_jumpButton))
        {
            JumpInputing?.Invoke();
        }

        if (Input.GetKeyDown(_attackButton))
        {
            AttackInputing?.Invoke();
        }
    }
}
