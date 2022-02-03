using System.Collections;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Skeleton : Undead
{
    
    [SerializeField]private float _speed;
    [SerializeField]private float _attackDelay;
    [SerializeField]private int _health;
    [SerializeField]private int _damage;
    [SerializeField]private state _nowState;
    private BoxCollider2D _boxCollider2D;
    private Transform _transform;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    Human _human;

    enum state
    {
        idle,
        move,
        attack,
        death
    }
    protected override void Move(Vector2 vector,float speed)
    {
        _rigidbody.AddForce(vector * speed);
    }
    private 

    void Start()
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
        _animator.Play("Idle");
        while (_nowState == state.idle)
        {
            yield return null;
            yield break;
        }
    }
    private IEnumerator StateMove()
    {
        _nowState = state.move;
        _animator.Play("Move");
        while (_nowState == state.move)
        {
              Move(Vector2.left,_speed);
            if (_human != null)
            {
                StartCoroutine(StateAttack());
                yield break;
            }
            yield return null;
        }
    }
    private IEnumerator StateAttack()
    {
        _nowState = state.attack;
        float elapsedTime = 0f;
        while (_nowState == state.attack)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= _attackDelay)
            {
                elapsedTime = 0f;
                _animator.Play("Attack");
                _human.TakeDamage(_damage);
            }
            if (_human != null)
            {
                StartCoroutine(StateMove());
                yield break;
            }
            yield return null ;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Human human))
        {
           _human = human;
        }
    }
    public override void TakeDamage(int damage)
    {
        _health -= damage;
    }
    void Update()
    {
        
    }

}
