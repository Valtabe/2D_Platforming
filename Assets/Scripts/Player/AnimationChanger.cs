using UnityEngine;

public class AnimationChanger : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        _inputReader.DirectionButtonStateChange += Change;
    }
    private void OnDisable()
    {
        _inputReader.DirectionButtonStateChange -= Change;
    }

    private void Change(bool state)
    {
        _animator.SetBool("isRunning", state);
    }
}
