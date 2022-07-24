using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootHuman : Battler
{
    [SerializeField] protected float _distance;
    [SerializeField] protected GameObject _eye;
    [SerializeField] protected GameObject _target;
    [SerializeField] protected Arrow _arrow;
    [SerializeField] protected typeAttack _typeAttack;
    [SerializeField] protected LayerMask _layerMask;
    [SerializeField] private float _speedAnimationShoot;
    private int ShootAnimation = Animator.StringToHash("Shoot");

    protected enum typeAttack
    {
        range,
        melee
    }
    public override void Attack()
    {
        if (_typeAttack == typeAttack.range)
        {
            Invoke("SpawnArrow", 10f);
        }
        if (_typeAttack == typeAttack.melee)
        {
            base.Attack();
        }
    }
    protected override void Move(float speed)
    {
        base.Move(speed);
        _raycastHit = Physics2D.Raycast(_eye.transform.position, Vector2.right, _distance, _layerMask);
        Shooting();

    }
    public void Shooting()
    {
        if (_raycastHit.collider != null && !_raycastHit.collider.GetComponent<Human>())
        {
            if (_raycastHit.transform.GetComponent<Undead>())
            {
                Debug.DrawRay(_eye.transform.position, transform.right * _distance, Color.red);
                Debug.Log(_raycastHit.collider.gameObject.name);
                ChangeAttack();
                _battlerAttack = _raycastHit.transform.GetComponent<Undead>();
                _attackPurpose = _battlerAttack.gameObject;
            }
            if (_raycastHit.collider.GetComponent<UndeadBuilding>())
            {
                ChangeAttack();
                _buildingAttack = _raycastHit.transform.GetComponent<Building>();
                _attackPurpose = _buildingAttack.gameObject;
            }
            Debug.DrawRay(_eye.transform.position, transform.right * _distance, Color.red);
        }
        else
        {
            Debug.DrawRay(_eye.transform.position, transform.right * _distance, Color.green);
        }
    }
    public IEnumerator TypeAttackRange()
    {
        _typeAttack = typeAttack.range;
        while (_typeAttack == typeAttack.range)
        {
            _raycastHit = Physics2D.Raycast(_eye.transform.position, Vector2.right, _distance);
            if (_raycastHit.collider != null)
            {
                if (_raycastHit.transform.GetComponent<Undead>())
                {
                    Debug.Log(_raycastHit.collider.gameObject.name);
                    _typeAttack = typeAttack.range;
                    _battlerAttack = _raycastHit.transform.GetComponent<Undead>();
                    Attack();
                }
                if (_raycastHit.transform.GetComponent<UndeadBuilding>())
                {
                    Debug.Log(_raycastHit.collider.gameObject.name);
                    _typeAttack = typeAttack.range;
                    _buildingAttack = _raycastHit.transform.GetComponent<UndeadBuilding>();
                    Attack();
                }

                Debug.DrawRay(_eye.transform.position, transform.right * _distance, Color.green);
            }
            else
            {
                Debug.DrawRay(_eye.transform.position, transform.right * _distance, Color.red);
            }

            yield return null;
        }
    }
    public IEnumerator TypeAttackMelee()
    {
        _typeAttack = typeAttack.melee;
        while (_typeAttack == typeAttack.melee)
        {
            if (_raycastHit.collider != null)
            {
                Attack();
                yield break;
            }
            if (_raycastHit.transform.gameObject.TryGetComponent(out Undead undead))
            {
                Attack();

                yield break;
            }
            yield return null;
        }
    }

    public void SpawnArrow()
    {
        _animator.StopPlayback();
        _animator.Play(ShootAnimation);
        Instantiate(_arrow, _target.transform);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Undead undead))
        {
            _typeAttack = typeAttack.melee;
        }
    }
    public void ChangeAttack()
    {
        if (_typeAttack == typeAttack.melee)
        {
            _typeAttack = typeAttack.range;
        }
    }
}
