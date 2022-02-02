using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider HealthSlider;
    public Human Human;
    private void Start()
    {
        HealthSlider = GetComponent<Slider>();
        HealthSlider.maxValue = Human.Health;
    }
    private void FixedUpdate()
    {
        HealthSlider.value = Human.Health;
    }

}
