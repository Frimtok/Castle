using UnityEngine;

public class UndeadBoss : MonoBehaviour
{
    [SerializeField] protected state _nowState;
    protected enum state
    {
        idle,
        attack,
        death
    }
    public virtual int GetHealth() { return 1; }

    public virtual void TakeDamage(int damage) { }
}
