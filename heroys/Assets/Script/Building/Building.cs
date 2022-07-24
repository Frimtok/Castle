using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Building : MonoBehaviour
{ 
    [SerializeField]private int _health;
    public delegate void View(int health);
    public event View OnView;
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void TakeDamage(int damage)
    {
        _health -= damage;
        OnView?.Invoke(_health);
    }
    public int GetHealth()
    {
        return _health;
    }
}
