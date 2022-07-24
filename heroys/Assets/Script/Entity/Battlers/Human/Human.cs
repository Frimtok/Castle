using UnityEngine;
public abstract class Human : Battler
{
    protected override bool OnQueue()
    {
        Debug.DrawRay(_rayQueue.transform.position, transform.right * _distanceQueue, Color.red);
        _raycastHit = Physics2D.Raycast(_rayQueue.transform.position, Vector2.right, _distanceQueue);
        if (_raycastHit.collider != null)
        {
            if (_raycastHit.transform.GetComponent<Human>())
            {
                Debug.DrawRay(_rayQueue.transform.position, transform.right * _distanceQueue, Color.green);
                return false;
            }
            return true;
        }
        return true;
    }
    protected override void Move(float speed)
    {
        base.Move(-speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Undead undead))
        {
            _attackPurpose = undead.gameObject;
            _battlerAttack = undead;
        }
        if (collision.gameObject.TryGetComponent(out UndeadBuilding castle))
        {
            _attackPurpose = castle.gameObject;
            _buildingAttack = castle;
        }
    }
}
