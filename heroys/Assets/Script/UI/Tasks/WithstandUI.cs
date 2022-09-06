using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WithstandUI : UITasks
{
    private const string NAMETASKRU = "ќборон€йтесь";
    private const string NAMETASKEN = "hold out";
    [SerializeField]private Text _waitSecond;
    [SerializeField]private Text _needSecond;

    public void SetWaiting(double second)
    {
        _waitSecond.text = Math.Truncate(second).ToString();
    }
    public void SetNeedSecond(int second)
    {
        _needSecond.text = $"/ {second}";
    }
    void Start()
    {
        HideTaskUI();
        if (_translation._language == Translation.Language.en)
        {
            ConditionTask(NAMETASKEN);
        }
        if (_translation._language == Translation.Language.ru)
        {
            ConditionTask(NAMETASKRU);
        }
    }

}
