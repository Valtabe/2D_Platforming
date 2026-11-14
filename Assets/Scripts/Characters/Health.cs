using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float _maxValue;
    [SerializeField] private float _minValue;
    [SerializeField] private float _currentValue;

    public event Action Died;

    public void Start()
    {
        _currentValue = _maxValue;
    }

    public void TakeDamage(float damageValue)
    {
        _currentValue -= damageValue;

        if (_currentValue < _minValue)
        {
            _currentValue = _minValue;
            Died?.Invoke();
        }
    }

    public void Regenerate(float value)
    {
        _currentValue += value;

        if (_currentValue > _maxValue)
        {
            _currentValue = _maxValue;
        }
    }
}
