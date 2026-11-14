using System;
using System.Collections;
using UnityEngine;

public class AttackerEnemy : MonoBehaviour, IAttacker
{
    [SerializeField] private float _damage;
    [SerializeField] private float _activateAttackRange;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _attackRate;
    [SerializeField] private Transform _weaponPoint;
    [SerializeField] private LayerMask _player;

    public event Action Attacking;

    private WaitForSeconds _waitAttackRate;
    private RaycastHit2D _hitInImpact;
    private RaycastHit2D _hitPlayer;

    private void Start()
    {
        _waitAttackRate = new WaitForSeconds(_attackRate);
    }

    public IEnumerator FindingChanceToAttack(Player target)
    {
        while (enabled)
        {
            _hitInImpact = Physics2D.Raycast(_weaponPoint.transform.position, transform.right, _activateAttackRange, _player);

            if ((_hitInImpact.collider != null) && (_hitInImpact.collider.TryGetComponent<Player>(out Player player)))
            {
                Attacking?.Invoke();
                Attack();
            }

            yield return _waitAttackRate;
        }
    }

    public void Attack()
    {
        _hitPlayer = Physics2D.Raycast(_weaponPoint.transform.position, transform.right, _attackRange, _player);

        if ((_hitPlayer.collider != null) && (_hitPlayer.collider.TryGetComponent<Player>(out Player player)))
        {
            player.TakeDamage(_damage);
        }
    }
}
