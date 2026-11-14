using UnityEngine;

public class AnimationChanger : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Change(bool state)
    {
        _animator.SetBool("isRunning", state);
    }

    public void PlayAttack()
    {
        _animator.Play("Attack", -1, 0f);
    }
}
