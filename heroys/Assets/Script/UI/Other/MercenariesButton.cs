using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MercenariesButton : HumanButton
{
    [SerializeField]private Human _human;
    private Bank _bank;
    private Image _image;

    public void OnSpawn(SpawnPoint spawnPoint)
    {
        if (_price <= _bank.GetMoney() && IsDelay())
        {
            _bank.DecrementMoney(_price);
            Spawn(spawnPoint);
            ColorImage(_image,new Color(0.67f,0.08f,0.11f,1f));
            Delay(_image);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(_buttonSpawn))
        {
            OnSpawnToKey();
        }
    }
    private void OnSpawnToKey()
    {
        OnSpawn(_spawnPoint);
    }
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void Spawn(SpawnPoint spawnPoint)
    {
        _audioSource.Play();
        spawnPoint.AddHuman(_human);
    }
    private void OnEnable()
    {
        _bank = FindObjectOfType<Bank>();
        _image = GetComponent<Image>();
    }
}
