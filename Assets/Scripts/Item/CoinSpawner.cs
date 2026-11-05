using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private List<int> _availableSpawnPoints = new List<int>();

    private ObjectPool<Coin> _pool;
    private WaitForSeconds _wait;
    private int _poolCapacity = 3;
    private int _poolMaxSize = 3;

    private Coroutine _coinSpawnCoroutine;

    private void Awake()
    {
        _pool = new ObjectPool<Coin>(
           createFunc: () => Instantiate(_coinPrefab),
           actionOnGet: (coin) => ActionOnGet(coin),
           actionOnRelease: (coin) => ActionOnRealese(coin),
           actionOnDestroy: (coin) => Destroy(coin.gameObject),
           collectionCheck: true,
           defaultCapacity: _poolCapacity,
           maxSize: _poolMaxSize);
    }

    private void Start()
    {
        _wait = new WaitForSeconds(_spawnDelay);

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            _availableSpawnPoints.Add(i);
        }

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            TakeFromPool();
        }
    }

    private void ActionOnGet(Coin coin)
    {
        int spawnPointNumber = _availableSpawnPoints[UnityEngine.Random.Range(0, _availableSpawnPoints.Count)];
        coin.transform.position = _spawnPoints[spawnPointNumber].position;
        coin.transform.rotation = Quaternion.identity;
        coin.SetPositionNumber(spawnPointNumber);
        _availableSpawnPoints.Remove(spawnPointNumber);
        coin.gameObject.SetActive(true);
        coin.CoinTaked += _pool.Release;

        if ((_availableSpawnPoints.Count == 0) && (_coinSpawnCoroutine != null))
        {
            StopCoroutine(_coinSpawnCoroutine);
            _coinSpawnCoroutine = null;
        }
    }

    private void ActionOnRealese(Coin coin)
    {
        coin.gameObject.SetActive(false);
        _availableSpawnPoints.Add(coin.PositionNumber());
        coin.CoinTaked -= _pool.Release;

        if (_coinSpawnCoroutine == null)
        {
            _coinSpawnCoroutine = StartCoroutine(SpawnCoinAfterDelay());
        }
    }

    private void TakeFromPool() => _pool.Get();

    private IEnumerator SpawnCoinAfterDelay()
    {
        while (_availableSpawnPoints.Count != 0)
        {
            yield return _wait;

            TakeFromPool();
        }
    }
}
