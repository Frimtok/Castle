using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Human Human;
    public Undead Undead;
    public GameObject _arrow;
    public GameObject SpawnArrow;
    private Rigidbody2D _rigidbody2D;
    private float speed = 10;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    public void Spawn(Transform spawn)
    {
        Instantiate(_arrow,spawn.position, Quaternion.identity);
    }
    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(speed, _rigidbody2D.velocity.y);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var Player1 = collision.gameObject;
            Undead = Player1.GetComponent<Undead>();
            Destroy(gameObject);
            Undead.TakeDamage(Human._powerAttack);
        }

    }
}
