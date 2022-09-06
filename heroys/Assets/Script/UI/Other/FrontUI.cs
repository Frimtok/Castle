using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FrontUI : InterfaceUI
{
    [SerializeField] private Text _textMoney;
    private Bank _bank;
    private void OnEnable()
    {
        _bank = FindObjectOfType<Bank>();
        _bank.ViewMoney += ViewMoney;
    }
    private void ViewMoney(int money)
    {
        _textMoney.text = $"{money}";
    }
}
   