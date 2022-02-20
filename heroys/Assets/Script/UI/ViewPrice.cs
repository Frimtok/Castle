using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewPrice : InterfaceUI
{
     private Text _priceText;
    HumanButton _humanButtun;
    private void OnEnable()
    {
        _humanButtun = GetComponentInParent<HumanButton>();
        _priceText = GetComponent<Text>();
        _priceText.text = $"{_humanButtun.GetPrice()}";
    }
}
