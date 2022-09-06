using System.Collections.Generic;
using UnityEngine;

public class Arrow : Ammunition
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Undead battler))
        {
            if (battler.TryGetComponent(out Darkknight darkknight))
            {
                darkknight.TakeDamage(_damage / 2);
            }
            else
            {
                battler.TakeDamage(_damage);
            }
                Destroy(gameObject);
        }
        if (collision.gameObject.TryGetComponent(out UndeadBuilding building))
        {
            building.TakeDamage(_damage);
            Destroy(gameObject);

        }
        if (collision.gameObject.TryGetComponent(out UndeadBoss undeadBoss))
        {
            undeadBoss.TakeDamage(_damage);
            Destroy(gameObject);

        }
    }
}
