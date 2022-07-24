using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UndeadShoot : Undead
{

    [SerializeField] private float _distance;
    [SerializeField] private GameObject _eye;
    [SerializeField] private GameObject _target;
    [SerializeField] private Arrow _bolt;
    [SerializeField] private typeAttack _typeAttack;
    [SerializeField] private LayerMask _layerMask;
    private int ShootAnimation = Animator.StringToHash("Shoot");
    [SerializeField] public float _speedAnimationShoot;
    private enum typeAttack
    {
        range,
        melee
    }
    public void ChangeAttack()
    {
        if (_typeAttack == typeAttack.melee)
        {
            _typeAttack = typeAttack.range;
        }
    }

    public void SpawnArrow()
    {
        Instantiate(_bolt, _target.transform);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Human human))
        {
            _typeAttack = typeAttack.melee;
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
            if (_raycastHit.transform.gameObject.TryGetComponent(out Human human))
            {
                Attack();

                yield break;
            }
            yield return null;
        }
    }
    public IEnumerator TypeAttackRange()
    {
        _typeAttack = typeAttack.range;
        while (_typeAttack == typeAttack.range)
        {
            _raycastHit = Physics2D.Raycast(_eye.transform.position, Vector2.right, -_distance);
            if (_raycastHit.collider != null)
            {
                if (_raycastHit.transform.GetComponent<Human>())
                {
                    Debug.Log(_raycastHit.collider.gameObject.name);
                    _typeAttack = typeAttack.range;
                    _battlerAttack = _raycastHit.transform.GetComponent<Human>();
                    Attack();
                }
                if (_raycastHit.transform.GetComponent<HumanBuilding>())
                {
                    Debug.Log(_raycastHit.collider.gameObject.name);
                    _typeAttack = typeAttack.range;
                    _buildingAttack = _raycastHit.transform.GetComponent<HumanBuilding>();
                    Attack();
                }

                Debug.DrawRay(_eye.transform.position, transform.right * -_distance, Color.green);
            }
            else
            {
                Debug.DrawRay(_eye.transform.position, transform.right * -_distance, Color.red);
            }

            yield return null;
        }
    }
    public void Shooting()
    {
        if (_raycastHit.collider != null && !_raycastHit.collider.GetComponent<Undead>())
        {
            if (_raycastHit.transform.GetComponent<Human>())
            {
                Debug.DrawRay(_eye.transform.position, transform.right * -_distance, Color.red);
                Debug.Log(_raycastHit.collider.gameObject.name);
                ChangeAttack();
                _battlerAttack = _raycastHit.transform.GetComponent<Human>();
                _attackPurpose = _battlerAttack.gameObject;
            }
            if (_raycastHit.collider.GetComponent<HumanBuilding>())
            {
                ChangeAttack();
                _buildingAttack = _raycastHit.transform.GetComponent<Building>();
                _attackPurpose = _buildingAttack.gameObject;
            }
            Debug.DrawRay(_eye.transform.position, transform.right * -_distance, Color.red);
        }
        else
        {
            Debug.DrawRay(_eye.transform.position, transform.right * -_distance, Color.green);
        }
    }
    protected override void Move(float speed)
    {
        base.Move(speed);
        _raycastHit = Physics2D.Raycast(_eye.transform.position, Vector2.right, -_distance, _layerMask);
        Shooting();
    }
    public override void Attack()
    {
        if (_typeAttack == typeAttack.range)
        {
            _animator.StopPlayback();
            _animator.Play(ShootAnimation);
            Invoke("SpawnArrow", _speedAnimationShoot);
        }
        if (_typeAttack == typeAttack.melee)
        {
            base.Attack();
        }
    }
}
