using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HumanButton : MonoBehaviour
{
    [SerializeField] protected int _price;
    public virtual int GetPrice()
    {
        return _price;
    }
}
