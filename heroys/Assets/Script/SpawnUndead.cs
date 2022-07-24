using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUndead : MonoBehaviour
{
    public List<SpawnObject> EnemyObjects;
    private float _nowTime = 0;
    private float _timeReapit = 0;

    protected IEnumerator Wait(SpawnObject enemy)
    {
       while (true)
       {
            if (enemy._isActive)
            {

                if (enemy.Time == _nowTime)
                {
                    for (int i = 0; i < enemy.Quantity; i++)
                    {
                        SapwnUndead(enemy);
                    }
                    yield break;
                }
                GetTimer();
            }
            else
            {
                    yield break;
            }
                yield return null;
       }
    }
    private void Start()
    {
        StartCoroutine(GetTimer());
    }
    private void Update()
    {
        foreach (var enemy in EnemyObjects)
        {

            if (enemy._isActive)
            {
                if (enemy.IsRepeat)
                {
                    if (_nowTime == CalculateRepetition(_timeReapit,enemy.Time))
                    {
                        _timeReapit += _nowTime;
                        SapwnUndead(enemy);
                    }
                }
                else
                {
                    if (enemy.Time == _nowTime)
                    {
                        enemy._isActive = false;
                        SapwnUndead(enemy);
                    }
                }
            }
        }
    }
    private void SapwnUndead(SpawnObject spawnObject)
    {
            for (int i = 0; i < spawnObject.Quantity; i++)
            {
                Instantiate(spawnObject.Undead.gameObject,new Vector2(transform.position.x + i, transform.position.y),Quaternion.identity);
            }
    }
    IEnumerator GetTimer()
    {
        while (true)
        {
            ++_nowTime;
            yield return new WaitForSeconds(0.5f);
        }
    }
    private void NulledTimer()
    {
        _nowTime = 0;
    }
    private float CalculateRepetition(float nowTime, float timeUndead)
    {
       return nowTime + timeUndead;
    }
}
[System.Serializable]
public class SpawnObject
{
    public string Name;
    public Sprite Image;
    public Undead Undead;
    public float Time;
    public int Quantity;
    public bool IsRepeat;
    public bool _isActive = true;
}
