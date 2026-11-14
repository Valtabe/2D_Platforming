using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Patroler _patroler;
    [SerializeField] private Seeker _seeker;
    [SerializeField] private AttackerEnemy _attacker;
    [SerializeField] private Follower _follower;
    [SerializeField] private EnemyAnimationHandler _animationHandler;
    [SerializeField] private Health _health;

    [SerializeField] private ActionType _currentAction;

    private Player _targetPlayer;

    enum ActionType
    {
        Patrol,
        Follow
    }

    private void OnEnable()
    {
        _seeker.PlayerFinded += StartFollow;
        _attacker.Attacking += PlayAttackAnimation;
        _health.Died += Dead;
    }

    private void OnDisable()
    {
        _seeker.PlayerFinded -= StartFollow;
        _attacker.Attacking -= PlayAttackAnimation;
        _health.Died -= Dead;
    }

    private void Start()
    {
        _currentAction = ActionType.Patrol;
    }

    private void Update()
    {
        _seeker.SeekPlayer();

        if (_currentAction == ActionType.Patrol)
        {
            _patroler.Patrol();
        }
        else if (_currentAction == ActionType.Follow)
        {
            _follower.Follow(_targetPlayer);
        }
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }    

    private void StartFollow(Player player)
    {
        player.Died += StopFollow;
        _targetPlayer = player;
        _currentAction = ActionType.Follow;
        StartCoroutine(_attacker.FindingChanceToAttack(_targetPlayer));
        _seeker.LosedSight += StopFollow;
    }

    private void StopFollow()
    {
        StopAllCoroutines();
        _targetPlayer = null;
        _currentAction = ActionType.Patrol;
        _seeker.LosedSight -= StopFollow;
        _seeker.LosedSight -= StopFollow;
    }

    private void PlayAttackAnimation() =>
        _animationHandler.PlayAttack();

    private void Dead()
    {
        Destroy(gameObject);
    }
}
