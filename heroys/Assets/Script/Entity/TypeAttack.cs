using UnityEngine;

public abstract class TypeAttack : MonoBehaviour
{
    public abstract void Action();
    public abstract TypeAttack GetTypeAttack();

    public abstract string GetNameAnimator();

    public abstract float GetSpeedAnamator();
}
