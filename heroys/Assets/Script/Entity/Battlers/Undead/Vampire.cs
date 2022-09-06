using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampire : Undead
{
    private int FlyAnimation = Animator.StringToHash("Fly");
    private int TransformationAnimation = Animator.StringToHash("Transformation");
    [SerializeField]private float _flySpeed;
    [SerializeField]private float _flyAnimationSpeed;
    
    protected override void Move(float speed)
    {
        if (Random.Range(1, 10) > 5)
        {
            _nowState = state.fly;
            _animator.StopPlayback();
            _animator.Play(TransformationAnimation);
            Invoke("Transformation", _flyAnimationSpeed);
        }
        else
        {
            _animator.Play(MoveAnimation);
            base.Move(speed);
        }
    }
    private void Transformation()
    {
            StartCoroutine(Fly());
    }
    private IEnumerator Fly()
    {
        while (_nowState == state.fly)
        {
            Flying();
            if (_attackPurpose != null)
            {
                StartCoroutine(StateAttack());
                yield break;
            }
            yield return null;
        }
    }
    private void Flying()
    {
        _animator.Play(FlyAnimation);
        _rigidbody.velocity = new Vector2(-_flySpeed, 0);

    }
}
