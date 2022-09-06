using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Slider))]

public class HealthBarNecromance : InterfaceUI
{
    private Slider _healthSlider;
    private Necromancer _undeadBoss;
    private void ViewHealth(int health)
    {
        _healthSlider.value = health;
    }
    private void Start()
    {
        _healthSlider = GetComponent<Slider>();
        _undeadBoss = GetComponentInParent<Necromancer>();
        _healthSlider.maxValue = _undeadBoss.GetHealth();
        _healthSlider.value = _undeadBoss.GetHealth();
        _undeadBoss.OnView += ViewHealth;
    }
}
