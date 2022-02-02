using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Human : MonoBehaviour, IProperty
{
    public Undead Undead;
    public Castle Castle;
    public Arrow Arrow;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private Transform SpawnArrow;
    public Slider HealthBar;
    public Canvas canvas;
    public int _powerAttack;
    private float _speed = 0;
    public int Cost = 5;
    public int Health;

    private bool _isArcher = false;
    private bool _isAttack = false;
    private float _timeAttack = 0;
    public Soldier TypeSoldire;
    public float Distance = 30;
    public enum Soldier
    {
        Pikeman,
        Archere,
        Chempion,
        Castle
    }
    private void Start()
    {
        SpawnArrow = GetComponent<Transform>();
        switch (TypeSoldire)
        {
            case Soldier.Pikeman:
                Cost = 5;
                Health = 20;
                _powerAttack = 4;
                _speed = 2.3f;
                _timeAttack = 1;
                _isArcher = false;
                break;
            case Soldier.Archere:
                Cost = 10;
                Health = 15;
                _powerAttack = 2;
                _speed = 1.3f;
                _timeAttack = 6;
                _isArcher = true;
                break;
            case Soldier.Chempion:
                Cost = 15;
                Health = 40;
                _powerAttack = 5;
                _speed = 5;
                _timeAttack = 1f;
                _isArcher = false;
                break;
            case Soldier.Castle:
                Health = 100;
                break;
            default:
                break;
        }
        HealthBar.maxValue = Health;
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void Attack()
    {
       
        _isAttack = true;
            if (Undead != null)
            {
            if (_isArcher)
            {
                _animator.Play("Idle");
                StartCoroutine(TamiDamage());
            }
            else
            {


                if (Undead.Health > 0)
                {
                    _animator.Play("Attack");
                    StartCoroutine(TamiDamage());
                }
                else
                {
                    _isAttack = false;
                }
            }
            }
        

    }
    IEnumerator TamiDamage()
    {
        
        yield return new WaitForSeconds(_timeAttack);
        if (Undead != null)
        {
            
            if (_isArcher == true)
            {
                Debug.Log("dab dab");
                Arrow.Spawn(SpawnArrow);
                _animator.Play("Attack");
                Attack();
            }
            else
            {
                Undead.TakeDamage(_powerAttack);
                Attack();
            }
        }

    }
    private void Update()
    {
        if (Undead == null)
        {
            _isAttack = false;
            Move(_speed);
        }
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Move(float speed)
    {
        if (_isAttack == false)
        {
            _animator.Play("Go");
            _rigidbody2D.velocity = new Vector2(speed, _rigidbody2D.velocity.y);
        }
    }

    public void TakeDamage(int damage)
    {
        GetComponent<Renderer>().material.color = Color.red;
        Health -= damage;
        Invoke("ColorEnemies", 0.3f);
    }
    private void ColorEnemies()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        { 
            var Player1 = collision.gameObject;
            Undead = Player1.GetComponent<Undead>();

                if (_isAttack == false )
                {
                    Attack();
                }
        }
        if (collision.gameObject.tag == "Castle")
        {
            var Player2 = collision.gameObject;
            Castle = Player2.GetComponent<Castle>();
            Castle.TakeDamage(_powerAttack);
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        Move(_speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Undead == null)
        {
            var Player1 = collision.gameObject;
            Undead = Player1.GetComponent<Undead>();
            Attack();
        }
    }
}
