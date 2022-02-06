using System.Collections;
using UnityEngine;

public class Battler : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _attackDelay;
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private state _nowState;
    private BoxCollider2D _boxCollider2D;
    private Transform _transform;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    [SerializeField]protected GameObject _attackPurpose;
    [SerializeField]protected Battler _BattlerAttack;
    [SerializeField]protected Castle _castleAttack;
    private int IdleAnimation = Animator.StringToHash("Idle");
    private int MoveAnimation = Animator.StringToHash("Move");
    private int AttackAnimation = Animator.StringToHash("Attack");
    private int DeathAnimation = Animator.StringToHash("Death");
    [SerializeField] private float _speedAnimation;
    private enum state
    {
        idle,
        move,
        attack,
        death
    }
    public virtual void Attack()
    {
        if (_castleAttack != null)
        {
            _castleAttack.TakeDamage(_damage);
        }
        if (_BattlerAttack != null)
        {
            _BattlerAttack.TakeDamage(_damage);
        }
    }
    protected virtual void Move(float speed)
    {
        _rigidbody.velocity = new Vector2(-speed, 0);
    }
    protected virtual void TakeDamage(int damage)
    {
        if (_health <= 0)
        {
            StartCoroutine(StateDeath());
        }
        _health -= damage;
    }
    protected virtual void Zeroize()
    {
       _BattlerAttack = null;
    }
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        StartCoroutine(StateMove());
    }
    private IEnumerator StateIdle()
    {
        _nowState = state.idle;
        _animator.Play(IdleAnimation);
        while (_nowState == state.idle)
        {
            yield return null;
            yield break;
        }
    }
    private IEnumerator StateMove()
    {
        _animator.CrossFade(MoveAnimation, _speedAnimation);
        _nowState = state.move;
        _animator.Play(MoveAnimation);
        while (_nowState == state.move)
        {
            if (_attackPurpose != null)
            {
                StartCoroutine(StateAttack());
                yield break;
            }
            Move(_speed);
            yield return null;
        }
    }
    private IEnumerator StateAttack()
    {
        float timer = _attackDelay;
        _nowState = state.attack;
        while (_nowState == state.attack)
        {
            if (timer >= _attackDelay)
            {
                _animator.CrossFade(AttackAnimation, _speedAnimation);
                Attack();
                timer = 0;
            }
            else
            {
                timer += Time.deltaTime;
            }
            if (_attackPurpose == null)
            {
                StartCoroutine(StateMove());
                yield break;
            }
            yield return null;
        }
    }
    private IEnumerator StateDeath()
    {
        _nowState = state.death;
        _animator.CrossFade(DeathAnimation, _speedAnimation);
        Destroy(gameObject, _attackDelay);
        Zeroize();
        yield break;
    }
}
