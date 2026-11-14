using System;
using UnityEngine;

public class ItemTaker : MonoBehaviour
{
    public event Action CoinPickedUp;
    public event Action<float> AidPickedUp;

    private void OnTriggerEnter2D(Collider2D enteredObject)
    {
        if (enteredObject.gameObject.TryGetComponent<Coin>(out Coin coin))
        {
            coin.Take();
            CoinPickedUp?.Invoke();
        }

        if (enteredObject.gameObject.TryGetComponent<Aid>(out Aid aid))
        {
            aid.Take();
            AidPickedUp?.Invoke(aid.RegenerateValue);
        }
    }
}
