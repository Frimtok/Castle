using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : Ammunition
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Human battler))
        {
            if (battler.TryGetComponent(out Paladin paladin))
            {
                paladin.TakeDamage(_damage / 2);
            }
            else
            {
                battler.TakeDamage(_damage);
            }
            Destroy(gameObject);
        }
        if (collision.gameObject.TryGetComponent(out HumanBuilding building))
        {
            building.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}
