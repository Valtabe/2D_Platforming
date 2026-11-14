using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _coinCounter;

    private void Start()
    {
        _coinCounter = 0;
    }

    public void AddCoin() =>
        _coinCounter++;
}
