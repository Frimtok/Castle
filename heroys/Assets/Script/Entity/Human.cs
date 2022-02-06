using UnityEngine;
public abstract class Human : Battler
{
    protected override void Move(float speed)
    {
        base.Move(-speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Undead undead))
        {
            _attackPurpose = undead.gameObject;
            _BattlerAttack = undead;
        }
        if (collision.gameObject.TryGetComponent(out Castle castle))
        {
            _attackPurpose = castle.gameObject;
            _castleAttack = castle;
        }
    }
}
