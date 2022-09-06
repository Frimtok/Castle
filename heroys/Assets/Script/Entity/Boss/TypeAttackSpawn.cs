using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeAttackSpawn : TypeAttack
{
    [SerializeField] private float _speedAnamator;
    private Summoning _summoning;
    public override void Action()
    {
        _summoning.Spawn();
    }
    public override string GetNameAnimator()
    {
        return "Spawn";
    }

    public override float GetSpeedAnamator()
    {
       return _speedAnamator;
    }

    public override TypeAttack GetTypeAttack()
    {
        Debug.Log(this);
        return this;
    }
    private void Start()
    {
        _summoning = FindObjectOfType<Summoning>();
        Action();
    }
}
