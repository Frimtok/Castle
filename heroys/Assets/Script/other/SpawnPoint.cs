using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class SpawnPoint : MonoBehaviour
{
    [SerializeField]private List<Human> _human;
    private SpawnHumanUI _humanUI;
    private float timer = 0;
    [SerializeField] private float wait;
    public delegate void SpawnHuman(Human human);
    public event SpawnHuman SpawnHumanEvent;
    private AudioSource _spawnsound;

    private void Start()
    {
        _spawnsound = GetComponent<AudioSource>();
        _humanUI = GetComponent<SpawnHumanUI>();
        _humanUI.SetStartMax(wait);
    }

    private void Update()
    {
        _spawnsound = GetComponent<AudioSource>();
        if (_human.Count > 0)
        {
            if (timer >= wait)
            {
                timer = 0;
                _humanUI.ValueIndicator(timer);
                Spawn();
            }
            else
            {
                _humanUI.ValueIndicator(timer);
                timer += Time.deltaTime;
            }
        }
    }
    public void AddHuman(Human human)
    {
        _human.Add(human);
    }
    private void Spawn()
    {
             _spawnsound.Play();
             SpawnHumanEvent?.Invoke(_human[0]);
            Instantiate(_human[0],new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);
            _human.Remove(_human[0]);
    }
}
