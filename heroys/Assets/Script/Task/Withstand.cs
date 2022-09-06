using UnityEngine;
using System;

[RequireComponent(typeof(WithstandUI))]
public class Withstand : TaskList
{
    [SerializeField] private float _withstandinSecond;
    private float timer = 0;
    private WithstandUI _withstandUI;

    private void Start()
    {
        _withstandUI = GetComponent<WithstandUI>();
        _withstandUI.SetNeedSecond(int.Parse(_withstandinSecond.ToString()));
    }
    private void Update()
    {
        if (timer >= _withstandinSecond)
        {
            _withstandUI.SetWaiting(_withstandinSecond);
            if (timer >= _withstandinSecond)
            {
                Win();
            }
        }
        else
        {
            timer = Time.time;
            _withstandUI.SetWaiting(timer);
        }
    }
    protected override void Win()
    {
       _withstandUI.ShowWin();
        base.Win();
    }
}
