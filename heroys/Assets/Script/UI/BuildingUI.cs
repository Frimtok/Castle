using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Slider))]

public class BuildingUI : InterfaceUI
{
    private Slider _slider;
    private Building _castle;
    private void Start()
    {
        _slider = GetComponent<Slider>();
        _castle = GetComponentInParent<Building>();
        _slider.maxValue = _castle.GetHealth();
        _castle.OnView += ViewHealth; 

    }
    private void ViewHealth(int health)
    {
        _slider.value = health;
    }
}
