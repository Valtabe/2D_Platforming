using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _coinCounter;
    [SerializeField] private ItemTaker _itemTaker;

    private void OnEnable()
    {
        _itemTaker.CoinPickedUp += AddCoin;
    }

    private void OnDisable()
    {
        _itemTaker.CoinPickedUp -= AddCoin;
    }

    private void Start()
    {
        _coinCounter = 0;
    }

    private void AddCoin() =>
        _coinCounter++;
}
