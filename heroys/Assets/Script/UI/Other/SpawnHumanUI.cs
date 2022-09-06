using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnHumanUI : MonoBehaviour
{
    [SerializeField]private Slider _expectationIndicator;

    public void ValueIndicator(float wait)
    {
        _expectationIndicator.value = wait;
    }
    public void SetStartMax(float MaxValue)
    {
        _expectationIndicator.maxValue = MaxValue;
    }
}
