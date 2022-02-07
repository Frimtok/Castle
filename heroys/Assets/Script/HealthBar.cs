using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Slider))]
public class HealthBar : InterfaceUI
{
    private Slider _healthSlider;
    Battler _battler;
    private void ViewHealth(int health)
    {
        _healthSlider.value = health;
    }
    private void Start()
    {
        _healthSlider = GetComponent<Slider>();
        _battler = GetComponentInParent<Battler>();
        _healthSlider.maxValue = _battler.GetHealth();
        _healthSlider.value = _battler.GetHealth();
        _battler.OnView += ViewHealth;
    }
}
