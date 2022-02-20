using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BankUI : InterfaceUI
{
    private Slider _moneyBar;
    private Text _moneyText;
    [SerializeField]private Bank Bank;
    private void TimerMoney(float speed)
    {
        _moneyBar.value = speed;
    }
    private void Start()
    {
        _moneyText = GetComponentInChildren<Text>();
        _moneyBar = GetComponentInChildren<Slider>();
        Bank = FindObjectOfType<Bank>();
        _moneyBar.maxValue = Bank.GetTimer();
        Bank.ViewSpeedMoney += ViewBank;
    }
    private void Reset()
    {
            
    }
    private void ViewBank(float speedMoney)
    {
        _moneyBar.value = speedMoney;
    }
}
