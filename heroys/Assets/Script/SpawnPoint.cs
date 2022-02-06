using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
   private Human _human;
    Transform _transform;

    public void OnSpawn(Human human)
    {
        _human = human;
        Spawn(_human);
    }
    private void Spawn(Human human)
    {
        Instantiate(human,_transform);
    }
    private void Start()
    {
        _transform = GetComponent<Transform>();
    }
}
