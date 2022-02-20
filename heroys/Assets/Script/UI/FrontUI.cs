using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrontUI : InterfaceUI
{
    [SerializeField] private Text _textMoney;
    SpawnPoint _spawnPoint;
    private Bank _bank;
    private void OnEnable()
    {
        _bank = FindObjectOfType<Bank>();
        _spawnPoint = FindObjectOfType<SpawnPoint>();
        _bank.ViewMoney += ViewMoney;
    }
    private void ViewMoney(int money)
    {
        
        _textMoney.text = $"{money}";
    }
}
