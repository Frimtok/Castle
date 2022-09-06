using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Slider))]

public class BuildingUI : InterfaceUI
{
    [SerializeField]private Slider _slider;
    [SerializeField]private Building _castle;
    private void Start()
    {
        _slider = GetComponent<Slider>();
        _castle = GetComponentInParent<Building>();
        _slider.maxValue = _castle.GetHealth();
        ViewHealth(_castle.GetHealth());
        _castle.OnCastleEvent += ViewHealth; 

    }
    private void ViewHealth(int health)
    {
        _slider.value = health;
    }
}
