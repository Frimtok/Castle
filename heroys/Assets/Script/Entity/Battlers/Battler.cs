using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Animator))]
public class Battler : MonoBehaviour
{
    public delegate void View(int health);
    public event View OnView;
    [SerializeField] private float _speed;
    [SerializeField] private float _attackDelay;
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField]protected state _nowState;
    private BoxCollider2D _boxCollider2D;
    private Transform _transform;
    private Rigidbody2D _rigidbody;
    private AnimationClip clip;
    protected Animator _animator;
    protected GameObject _attackPurpose;
    protected Battler _battlerAttack;
    protected Building _buildingAttack;
    private int IdleAnimation = Animator.StringToHash("Idle");
    private int MoveAnimation = Animator.StringToHash("Move");
    private int AttackAnimation = Animator.StringToHash("Attack");
    private int DeathAnimation = Animator.StringToHash("Death");
    [SerializeField] protected float _speedAnimation;
    [SerializeField] protected float _speedAnimationAttack;
    [SerializeField] protected float _speedAnimationDead;
    protected RaycastHit2D _raycastHit;
    [SerializeField] protected float _distanceQueue;
    [SerializeField] protected GameObject _rayQueue;
    protected enum state
    {
        idle,
        move,
        attack,
        death
    }
    private void Update()
    {
        OnQueue();
    }
    public virtual void Attack()
    {
        Invoke("OnAttack", _speedAnimationAttack);
    }
    private void OnAttack()
    {
        if (_buildingAttack != null)
        {
            _buildingAttack.TakeDamage(_damage);
        }
        if (_battlerAttack != null)
        {
            _battlerAttack.TakeDamage(_damage);
        }
    }
    protected virtual bool OnQueue()
    {
        Debug.DrawRay(_rayQueue.transform.position, -transform.right * _distanceQueue, Color.red);
        _raycastHit = Physics2D.Raycast(_rayQueue.transform.position, Vector2.left, _distanceQueue);
        if (_raycastHit.collider != null)
        {
            if (_raycastHit.transform.GetComponent<Undead>())
            {
                Debug.DrawRay(_rayQueue.transform.position, -transform.right * _distanceQueue, Color.green);
                return false;
            }
            return true;
        }
        return true;
    }
    protected virtual void Move(float speed)
    {
        _rigidbody.velocity = new Vector2(-speed, 0);
    }
    public virtual void TakeDamage(int damage)
    {
        _health -= damage;
        OnView?.Invoke(_health);
        if (_health <= 0)
        {
            StartCoroutine(StateDeath());
        }
    }
    protected virtual void Zeroize()
    {
       _battlerAttack = null;
    }
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        if (_attackDelay < _speedAnimationAttack)
        {
            _speedAnimationAttack = _attackDelay + 0.5f;
        }
        StartCoroutine(StateMove());
    }
    public int GetHealth()
    {
        return _health;
    }
    protected IEnumerator StateIdle()
    {
        _nowState = state.idle;
        _animator.Play(IdleAnimation);
        while (_nowState == state.idle)
        {
            yield return null;
            yield break;
        }
    }
    protected void NulledSpeed()
    {
        _speed = 0;
    }
    protected  IEnumerator StateMove()
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
            if (OnQueue())
            {
                Move(_speed);
                _animator.Play(MoveAnimation);
            }
            if (OnQueue() == false)
            {
                _animator.Play(IdleAnimation);
            }
            yield return null;
        }
    }
    protected IEnumerator StateAttack()
    {
        float timer = _attackDelay;
        _nowState = state.attack;
        while (_nowState == state.attack)
        {
            if (timer >= _attackDelay)
            {
                if (_attackPurpose != null)
                {
                    _animator.CrossFade(AttackAnimation, _speedAnimation);
                    Attack();
                }
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
        Zeroize();
        _nowState = state.death;
        _boxCollider2D.isTrigger = true;
        _rigidbody.bodyType = RigidbodyType2D.Static;
        _animator.StopPlayback();
        _animator.CrossFade(DeathAnimation, _speedAnimation);
        Destroy(gameObject,_speedAnimationDead);
        yield break;
    }
}
