using System;
using System.Collections;
using UnityEngine;

public class Seeker : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private float _delayToLosePlayer;
    [SerializeField] private LayerMask _player;

    public event Action<Player> PlayerFinded;
    public event Action LosedSight;

    private bool _isPlayerVisible;
    private RaycastHit2D _spottedTarget; 
    private WaitForSeconds _waitToLosePlayer;
    private Coroutine _losingCoroutine;

    private void Start()
    {
        _waitToLosePlayer = new WaitForSeconds(_delayToLosePlayer);
        _isPlayerVisible = false;
    }

    public void SeekPlayer()
    {        
        _spottedTarget = Physics2D.Raycast(transform.position, transform.right, _range, _player);

        if (_spottedTarget.collider != null)
        {
            if ((_isPlayerVisible == false) && (_spottedTarget.collider.TryGetComponent<Player>(out Player player)))
            {
                PlayerFinded?.Invoke(player);
                _isPlayerVisible = true;

                if (_losingCoroutine != null)
                {
                    StopCoroutine( _losingCoroutine);
                    _losingCoroutine = null;
                }
            }
        }
        else if (_isPlayerVisible == true)
        {
            _isPlayerVisible = false;
            _losingCoroutine = StartCoroutine(LosingSightOfPlayer());
        }
    }

    private IEnumerator LosingSightOfPlayer()
    {
        yield return _waitToLosePlayer;

        _isPlayerVisible = false;
        LosedSight?.Invoke();

        yield break;
    }
}
