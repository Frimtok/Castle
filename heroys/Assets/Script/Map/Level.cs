using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField]protected string _name;
    public string GetName()
    {
        return _name;
    }
}
