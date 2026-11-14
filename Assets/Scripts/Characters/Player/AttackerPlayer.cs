using System;
using UnityEngine;

public class AttackerPlayer : MonoBehaviour, IAttacker
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private Transform _weaponPoint;
    [SerializeField] private LayerMask _enemyLayer;

    public event Action Attacking;

    private RaycastHit2D _hitEnemy;

    public void Attack()
    {
        _hitEnemy = Physics2D.Raycast(_weaponPoint.transform.position, transform.right, _attackRange, _enemyLayer);
        Attacking?.Invoke();

        if ((_hitEnemy.collider != null) && (_hitEnemy.collider.TryGetComponent<Enemy>(out Enemy enemy)))
        {
            enemy.TakeDamage(_damage);
        }
    }
}
