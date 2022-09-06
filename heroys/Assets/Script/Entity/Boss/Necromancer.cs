using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class Necromancer : UndeadBoss
{
    public List<TypeAttacks> TypeAttacks;
    protected float _nowTime = 0;
    protected float _timeReapit = 0;
    public int Health;
    public delegate void View(int health);
    public event View OnView;
    [SerializeField] private float _attackDelay;
    [SerializeField]private float _speedAnimationAttack;
    private Animator _animator;
    [SerializeField] private float _speedAnimation;
    private TypeAttacks _nowTypeAttack;
    protected int IdleAnimation = Animator.StringToHash("TakeAwayGold");
    private AudioSource _deadSound;
    private void Start()
    {
        _deadSound = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();   
        StartCoroutine(Idle());
    }
    public override void TakeDamage(int damage)
    {
        Health -= damage;
        OnView?.Invoke(Health);
        if (Health <= 0)
        {
            StartCoroutine(Death());
        }
    }
    public override int GetHealth()
    {
        return Health;
    }
    private void Update()
    {
        foreach (var TypeAttack in TypeAttacks)
        {

            if (TypeAttack._isActive)
            {
                    if (TypeAttack.Time < _nowTime - 0.2 && TypeAttack.Time < _nowTime + 0.2)
                    {
                        TypeAttack._isActive = false;
                        StartCoroutine(StateAttack(TypeAttack));
                    }
                    else
                    {
                        _nowTime = Time.time;
                    }
            }
        }
    }
    private IEnumerator Idle()
    {
        _nowState = state.idle;
        while (_nowState == state.idle)
        {
            yield return null;
        }
    }
    private IEnumerator Death()
    {
        _nowState = state.death;
        _deadSound.Play();
        while (_nowState == state.death)
        {
            _animator.StopPlayback();
            _animator.Play("Death");
            Destroy(gameObject, 2);
            yield break;
        }
    }
    private IEnumerator StateAttack(TypeAttacks typeAttack)
    {
        float timer = _attackDelay;
        _nowState = state.attack;
        while (_nowState == state.attack)
        {
            if (timer >= _attackDelay)
            {
                _nowTypeAttack = typeAttack;
                _animator.Play(_nowTypeAttack.TypeAttack.GetNameAnimator());
                Attack();
                StartCoroutine(Idle());
                yield break;
            }
            else
            {
                timer += Time.deltaTime;
            }
            yield return null;
        }
    }
    private void Attack()
    {
        Invoke("OnAttack", _nowTypeAttack.TypeAttack.GetSpeedAnamator());
    }
    private void OnAttack()
    {
        if (_nowTypeAttack != null)
        {
            Instantiate(_nowTypeAttack.TypeAttack.gameObject);
        }
    }
}
[System.Serializable]
public class TypeAttacks
{
    public string Name;
    public Sprite Image;
    public TypeAttack TypeAttack;
    public float Time;
    public bool IsRepeat;
    public bool _isActive = true;
}
