using UnityEngine;

public class TypeAttackShoot : TypeAttack
{
    [SerializeField] private GameObject _target;
    [SerializeField] private Ammunition _arrow;
    [SerializeField] private float _speedAnamator;
    public override void Action()
    {
        Instantiate(_arrow, _target.transform.position, Quaternion.identity, _target.transform.parent);
    }

    public override string GetNameAnimator()
    {
        return "Shoot";
    }

    public override float GetSpeedAnamator()
    {
        return _speedAnamator;
    }

    public override TypeAttack GetTypeAttack()
    {
        Debug.Log(this);
        return this;
    }
    private void Start()
    {
        Action();
        Destroy(gameObject);
    }
}
