using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(UIDestroyEnemy))]
public class DestroyEnemy : TaskList
{
    [SerializeField] private int _count;
    private int _nowDead;
    private UIDestroyEnemy _uIDestroyEnemy;

    private void Start()
    {
        _uIDestroyEnemy = GetComponent<UIDestroyEnemy>();
        _uIDestroyEnemy.ShowDeadAll(_count);
        _uIDestroyEnemy.ShowDeadNow(_nowDead);
         Undead.DeadEnemyEvent += AddDead;
    }

    private void AddDead()
    {
        _nowDead++; 
        _uIDestroyEnemy.ShowDeadNow(_nowDead);
        if (_nowDead >= _count)
        {
            Win();
        }
    }
    public int GetDeadAll()
    {
        return _count;
    }
    public int GetDeadNow()
    {
        return _nowDead;
    }
    private void Nulled()
    {
        _nowDead = 0;
    }
    private void OnDisable()
    {
        Nulled();
        Undead.DeadEnemyEvent -= AddDead;
    }
    protected override void Win()
    {
        _uIDestroyEnemy.ShowWin();
        base.Win();
    }
}
