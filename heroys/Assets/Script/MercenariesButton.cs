using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercenariesButton : HumanButton
{
    [SerializeField]private Human _human;
    private Bank _bank;
    public void OnSpawn(SpawnPoint spawnPoint)
    {
        if (_price <= _bank.GetMoney())
        {
            _bank.DecrementMoney(_price);
            Spawn(spawnPoint);
        }
    }
    private void Spawn(SpawnPoint spawnPoint)
    {
        Instantiate(_human, spawnPoint.transform);
    }
    private void OnEnable()
    {
        _bank = FindObjectOfType<Bank>();
    }
}
