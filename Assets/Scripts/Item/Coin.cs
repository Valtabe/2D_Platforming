using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Coin : MonoBehaviour
{
    private int _positionNumber;

    public event Action<Coin> CoinTaked;

    public int PositionNumber() => _positionNumber;

    public void Take()
    {
        CoinTaked?.Invoke(this);
    }

    public void SetPositionNumber(int number) 
        => _positionNumber = number;
}
