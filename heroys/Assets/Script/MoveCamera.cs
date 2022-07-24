﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(Transform))]

public class MoveCamera : MonoBehaviour
{
    [SerializeField]private float _Right;
    [SerializeField]private float _Left;
    [SerializeField]private float _max, _min;
    [SerializeField] private float _stopRight, _stopLeft;
    private Transform _transform;
    [SerializeField] private float _speed; 
    private 
    void Update()
    {
        if (Input.mousePosition.x > _Right)
        {
            if (_transform.position.x < _stopRight)
            {
                 Move(_speed);
            }
        }
        if (Input.mousePosition.x < _Left)
        {
            if (_transform.position.x > _stopLeft)
            {
                Move(-_speed);
            }
        }
    }
    private void Start()
    {
       
        _Right = Screen.width - _max;
        _Left = 0 + _min;
        _stopRight = 30;
        _stopLeft = 0;
        _transform = GetComponent<Transform>();
    }
    private void Move(float speed)
    {
        _transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, _transform.position.y, _transform.position.z);
    }
}
