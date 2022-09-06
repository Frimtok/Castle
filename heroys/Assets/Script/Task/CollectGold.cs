using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(CollectGoldUI))]
public class CollectGold : TaskList
{
    [SerializeField]private int _needGold;
    [Inject] private Bank _bank;
    private CollectGoldUI _collectGoldUI;
    private void Start()
    {
        _collectGoldUI = GetComponent<CollectGoldUI>();
        _collectGoldUI.SetNeedMoney(_needGold);
        _bank.ViewMoney += Check;
    }

    private void OnDisable()
    {
        _bank.ViewMoney -= Check;
    }
    private void Check(int nowGold)
    {
        _collectGoldUI.SetMoney(nowGold);
        if (nowGold >= _needGold)
        {
            Win();
        }
    }
}
