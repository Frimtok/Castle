using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayQueue : MonoBehaviour
{
    [SerializeField] private Battler _battler;
    public Battler TypeObject()
    {
        return _battler;
    }
}
