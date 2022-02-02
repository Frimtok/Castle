using System;
using System.Collections;
using UnityEngine;


[Serializable]
public class Appearance : MonoBehaviour
{
    public float Wave;
    public int TimeWave;
    public int NumberEnemies;
    private Transform _transform;
    public GameObject Enemy;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        StartCoroutine(SpawnWait());
    }
    private void Spawn()
    {
        Wave++;
        for (int i = 0; i < NumberEnemies; i++)
        {
            
         Instantiate(Enemy, new Vector3(_transform.position.x + i , _transform.position.y , _transform.position.z) , Quaternion.identity);

        }
        StartCoroutine(SpawnWait());
    }
    private IEnumerator SpawnWait()
    {
        yield return new WaitForSeconds(TimeWave);
        Spawn();
    }
}
