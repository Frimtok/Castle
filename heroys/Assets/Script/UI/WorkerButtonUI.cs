using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkerButtonUI : InterfaceUI
{
    [SerializeField] private Text _maxWorkerText;
    [SerializeField] private Text _nowWorkerpriceText;
    WorkerButton _workerButton;

    private void OnEnable()
    {
        _workerButton = GetComponentInChildren<WorkerButton>();
        _workerButton.ViewPeasants += ViewPeasants;
    }
    private void ViewPeasants(int now, int max)
    {
        _nowWorkerpriceText.text = now.ToString();
        _maxWorkerText.text = " /"+ max.ToString();
    }
}
