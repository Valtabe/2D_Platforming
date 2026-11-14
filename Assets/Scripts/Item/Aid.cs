using System;
using UnityEngine;

public class Aid : MonoBehaviour
{
    [SerializeField] private float _regenerateValue;

    public event Action<Aid> Taked;

    public float RegenerateValue { get; private set; }

    private void Start()
    {
        RegenerateValue = _regenerateValue;
    }

    public void Take()
    {
        Taked?.Invoke(this);
    }
}
