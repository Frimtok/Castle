using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{ 
    public float Health = 100;
    public bool IsEnemy;
    public Slider Slider;
    public Canvas BarHealth;
    private Animator _animator;
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Invoke("ColorCastle",0.7f);
    }
    private void Start()
    {
        Slider.maxValue = Health;
        _animator = GetComponent<Animator>();
        BarHealth = GetComponent<Canvas>();
    }
    private void ColorCastle()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
    private void Update()
    {
        if (Health <= 0)
        {
            Slider.gameObject.SetActive(false);
            _animator.Play("Destroyed");
        }
        Slider.value = Health;
    }
}
