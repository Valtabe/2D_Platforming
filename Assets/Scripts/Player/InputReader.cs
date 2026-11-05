using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private readonly string _horizontal = "Horizontal";
    private readonly KeyCode _jumpButton = KeyCode.Space;

    public bool IsHorizontalInput = false;

    public event Action<float> DirectionInputing;
    public event Action JumpInputing;

    private void Update()
    {
        if (Input.GetAxis(_horizontal) != 0)
        {
            IsHorizontalInput = true;
            DirectionInputing?.Invoke(Input.GetAxis(_horizontal));
        }
        else
        {
            IsHorizontalInput = false;
        }


        if (Input.GetKey(_jumpButton))
        {
            JumpInputing?.Invoke();
        }
    }
}
