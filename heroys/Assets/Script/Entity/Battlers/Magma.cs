using UnityEngine;

public class Magma : Ammunition
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Human battler))
        {
            battler.TakeDamage(battler.GetHealth());
        }
        if (collision.gameObject.TryGetComponent(out HumanBuilding building))
        {
            Destroy(gameObject);
        }
    }
    protected override void IsBattlerAttack()
    {
        
    }
}
