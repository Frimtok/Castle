using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huskarl : Human
{
    private int _count;
    [SerializeField]private int _rageCount;
    [SerializeField]private int _rageAttack;
    private void OnEnable()
    {
        Undead.DeadEnemyEvent += DeadEnemy;
    }
    private void OnDisable()
    {
        Undead.DeadEnemyEvent -= DeadEnemy;
    }
    private void DeadEnemy()
    {
        _count++;
        Check();
    }
    private void Check()
    {
        if (_rageCount == _count)
        {
            Rage();
        }
    }
    private void Rage()
    {
        _damage += _rageAttack;
    }
}
