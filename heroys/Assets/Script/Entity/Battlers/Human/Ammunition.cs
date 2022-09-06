using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Ammunition : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeDestroy;
     private Battler _battlerAttack;
     private Building _buildingAttack;
     private UndeadBoss _undeadBoss;
    [SerializeField]protected int _damage;
    protected virtual void IsBattlerAttack()
    {
            if (_battlerAttack == null && _buildingAttack == null && _undeadBoss == null)
            {
                Destroy(gameObject);
            }
    }
    public void SetBattler(Battler battler) 
    {
            _battlerAttack =  battler;
    }
    public void SetBoss(UndeadBoss undeadBoss)
    {
        _undeadBoss = undeadBoss;
    }
    public void SetBuilding(Building building)
    {
            _buildingAttack = building;
    }

    private void Move(float speed)
    {
        _rigidbody.velocity = new Vector2(-speed, 0);
    }
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Destroy(gameObject, _timeDestroy);
    }
    private void Update()
    {
        Move(_speed);
        IsBattlerAttack();
    }
    public int GetDamage()
    {
        return _damage;
    }

}
