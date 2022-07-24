using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerButton : HumanButton
{
    [SerializeField] private int _maxPeasants;
    [SerializeField]private int _nowPeasants;
    public delegate void Peasants(int now,int max);
    public event Peasants ViewPeasants;
    private Bank _bank;
    private void OnEnable()
    {
        _bank = FindObjectOfType<Bank>();
    }
    public void AddMoney()
    {
        if (_price <= _bank.GetMoney() && IsMaxPeasants())
        { 
            _bank.DecrementMoney(_price);
            _bank.AddAddition();
            _nowPeasants++;
            ViewPeasants?.Invoke(_nowPeasants, _maxPeasants);
        }
    }
    private bool IsMaxPeasants()
    {
        if (_nowPeasants < _maxPeasants)
        {
            return true;
        }
        else
         return false;
    }
    private void Start()
    {
        ViewPeasants?.Invoke(_nowPeasants, _maxPeasants);
    }
}
