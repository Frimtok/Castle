using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darkknight : Undead
{
    private Ammunition _ammunition;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ammunition ammunition))
        {
            _ammunition = ammunition;
        }
        if (collision.gameObject.TryGetComponent(out Human human))
        {
            _attackPurpose = human.gameObject;
            _battlerAttack = human;
            _buildingAttack = null;
        }
        if (collision.gameObject.TryGetComponent(out HumanBuilding castle))
        {
            _attackPurpose = castle.gameObject;
            _buildingAttack = castle;
            _battlerAttack = null;
        }
    }
    public override void TakeDamage(int damage)
    {
        if (_ammunition != null)
        {
            base.TakeDamage(damage / 2);
        }
        else
        {
            base.TakeDamage(damage);
        }
    }
}
