using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public abstract class Undead : Battler
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Human human))
        {
            _attackPurpose = human.gameObject;
            _BattlerAttack = human;
        }
        if (collision.gameObject.TryGetComponent(out Castle castle))
        {
            _attackPurpose = castle.gameObject;
            _castleAttack = castle;
        }
    }
}
