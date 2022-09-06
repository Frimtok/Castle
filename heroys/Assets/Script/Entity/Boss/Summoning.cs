using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoning : MonoBehaviour
{
    private int _id;
    [SerializeField] private int[] Quantity;
    [SerializeField] private Undead[] _spawnObject;
    private ParticleSystem _particleSystem;

    private void AddId()
    {
        _id++;
    }
    public void Spawn()
    {
        _particleSystem.Play();
        if (_id <= _spawnObject.Length)
        {
            for (int i = 0; i < Quantity[_id]; i++)
            {
                Instantiate(_spawnObject[_id].gameObject, new Vector2(transform.position.x + (i - 0.4f), transform.position.y), Quaternion.identity);
            }
        }
        AddId();
    }
    private void Start()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
    }
}
