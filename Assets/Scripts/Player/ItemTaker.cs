using System;
using UnityEngine;

public class ItemTaker : MonoBehaviour
{
    public event Action CoinPickedUp;

    private void OnTriggerEnter2D(Collider2D enteredObject)
    {
        if (enteredObject.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            CoinPickedUp?.Invoke();
            coin.Take();
        }
    }
}
