using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectGoldUI : UITasks
{
    private const string NAMETASKRU = "Собрать золото";
    private const string NAMETASKEN = "Collect gold";
    [SerializeField]private Text _nowMoney;
    [SerializeField]private Text _needMoney;
    private void Start()    
    {
        HideTaskUI();
        if (_translation._language == Translation.Language.ru)
        {
            ConditionTask(NAMETASKRU);
        }
        if (_translation._language == Translation.Language.en)
        {
            ConditionTask(NAMETASKEN);
        }
    }
    public void SetNeedMoney(int money)
    {
        _needMoney.text = $" / {money}";
    }
    public void SetMoney(int money)
    {
        _nowMoney.text = money.ToString();
    }
    
}
