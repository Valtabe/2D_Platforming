using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class AidSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Aid _aidPrefab;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private int _poolCapacity = 1;
    [SerializeField] private int _poolMaxSize = 1;

    private ObjectPool<Aid> _pool;
    private WaitForSeconds _wait;
    private Coroutine _aidSpawnCoroutine;

    private bool _isAidSpawned;

    private void Awake()
    {
        _pool = new ObjectPool<Aid>(
            createFunc: () => Instantiate(_aidPrefab),
            actionOnGet: (aid) => ActionOnGet(aid),
            actionOnRelease: (aid) => ActionOnRelease(aid),
            actionOnDestroy: (aid) => Destroy(aid.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    private void Start()
    {
        _wait = new WaitForSeconds(_spawnDelay);
        _isAidSpawned = false;

        TakeFromPool();
    }

    private void ActionOnGet(Aid aid)
    {
        aid.transform.position = _spawnPoint.position;
        aid.transform.rotation = Quaternion.identity;
        aid.gameObject.SetActive(true);
        aid.Taked += _pool.Release;
        _isAidSpawned = true;

        if (_aidSpawnCoroutine != null)
        {
            StopCoroutine(SpawnAidAfterDelay());
            _aidSpawnCoroutine = null;
        }
    }

    private void ActionOnRelease(Aid aid)
    {
        _isAidSpawned = false;
        aid.gameObject.SetActive(false);
        aid.Taked -= _pool.Release;

        if (_aidSpawnCoroutine == null)
        {
            _aidSpawnCoroutine = StartCoroutine(SpawnAidAfterDelay());
        }
    }

    private void TakeFromPool() => _pool.Get();

    private IEnumerator SpawnAidAfterDelay()
    {
        while (_isAidSpawned == false)
        {
            yield return _wait;

            TakeFromPool();
        }
    }
}
