using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class TypeAttackTakeAwayGold : TypeAttack
{
    private Bank Bank;
    private AudioSource _decrementGold;
    [SerializeField] private float _speedAnamator;
    public override void Action()
    {
        _decrementGold.Play();
        Bank.DecrementMoney(Bank.GetMoney());
        Destroy(gameObject,1);
    }

    public override string GetNameAnimator()
    {
        return "TakeAwayGold";
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
        _decrementGold = GetComponent<AudioSource>();
        Bank = FindObjectOfType<Bank>();
        Action();
    }
}
