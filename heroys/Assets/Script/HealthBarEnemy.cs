using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemy : MonoBehaviour
{
    private Slider HealthSlider;
    public Undead Undead;
    private void Start()
    {
        HealthSlider = GetComponent<Slider>();
        HealthSlider.maxValue = Undead.Health;
    }
    private void FixedUpdate()
    {
        HealthSlider.value = Undead.Health;
    }
}
