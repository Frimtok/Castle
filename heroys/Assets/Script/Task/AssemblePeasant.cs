using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(AssemblePeasantUI))]
public class AssemblePeasant : TaskList
{
    [Inject] WorkerButton _workerButton;
    private AssemblePeasantUI _ui;
    [SerializeField] private int _needPeasant;
    private int _nowPeasant;

    private void Start()
    {
        _ui = GetComponent<AssemblePeasantUI>();
        _workerButton.ViewPeasants += AddPeasant;
        _ui.ViewPeasant(_workerButton.GetNowPeasants(), _needPeasant);
    }
    private void OnDisable()
    {
        _workerButton.ViewPeasants -= AddPeasant;
    }

    private void AddPeasant(int now, int max)
    {
        if (_needPeasant > max)
        {
            _needPeasant = max; 
        }
        else
        {
            _nowPeasant++;
            _ui.ViewPeasant(now, _needPeasant);
            if (_nowPeasant >= _needPeasant)
            {
                _ui.ShowWin();
                Win();
            }
        }
    }
}
