using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private ItemTaker _itemTaker;
    [SerializeField] private Health _health;
    [SerializeField] private AnimationChanger _animator;
    [SerializeField] private AttackerPlayer _attacker;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Mover _mover;
    [SerializeField] private Jumper _jumper;

    public event Action Died;

    private void OnEnable()
    {
        _itemTaker.CoinPickedUp += _wallet.AddCoin;
        _itemTaker.AidPickedUp += _health.Regenerate;
        _health.Died += Dead;
        _inputReader.AttackInputing += Attack;
        _inputReader.DirectionInputing += _mover.Move;
        _inputReader.JumpInputing += _jumper.Jump;
        _inputReader.DirectionButtonStateChange += _animator.Change;
    }

    private void OnDisable()
    {
        _itemTaker.CoinPickedUp -= _wallet.AddCoin;
        _itemTaker.AidPickedUp -= _health.Regenerate;
        _health.Died -= Dead;
        _inputReader.AttackInputing -= Attack;
        _inputReader.DirectionInputing -= _mover.Move;
        _inputReader.JumpInputing -= _jumper.Jump;
        _inputReader.DirectionButtonStateChange -= _animator.Change;
    }

    public void TakeDamage(float damageValue)
    {
        _health.TakeDamage(damageValue);
    }

    private void Attack()
    {
        _animator.PlayAttack();
        _attacker.Attack();
    }

    private void Dead()
    {
        Died?.Invoke();
        Destroy(gameObject);
    }
}
