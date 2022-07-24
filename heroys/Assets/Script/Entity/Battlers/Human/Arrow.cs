using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Arrow : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField]private float _speed;
    [SerializeField]private int _damage;
    [SerializeField] private float _timeDestroy;

    private void Move(float speed)
    {
        _rigidbody.velocity = new Vector2(-speed, 0);
    }
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        transform.SetParent(null);
        Destroy(gameObject,_timeDestroy);
    }

    private void Update()
    {
        Move(_speed);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Battler battler))
        {
            Destroy(gameObject);
            battler.TakeDamage(_damage);
        }
        if (collision.gameObject.TryGetComponent(out Building building))
        {
            Destroy(gameObject);
            building.TakeDamage(_damage);
        }
    }

}
