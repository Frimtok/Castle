using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public abstract class Undead : Battler
{
    public delegate void DeadEnemy();
    public DeadEnemy _deadEnemy;
    public static event DeadEnemy DeadEnemyEvent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
    private void OnDestroy()
    {
        if (_nowState == state.death)
        {
            if (DeadEnemyEvent != null)
            {
                DeadEnemyEvent?.Invoke();
            }
        }
    }
}
