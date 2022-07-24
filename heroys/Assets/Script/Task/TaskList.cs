using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskList : MonoBehaviour
{
    DestroyBuilding _destroyBuilding;
    Withstand _withstand;
    DestroyBoss _destroyBoss;
    DestroyEnemy _destroyEnemy;
    AssemblePeasant _assemblePeasant;
    AssembleSoldiers _assembleSoldiers;
    CollectGold _collectGold;


    public TaskList(DestroyBuilding destroyBuilding)
    {
        _destroyBuilding = destroyBuilding;
    }
    public TaskList(Withstand withstand)
    {
        _withstand = withstand;
    }
    public TaskList(DestroyBoss destroyBoss)
    {
        _destroyBoss = destroyBoss;
    }
    public TaskList(DestroyEnemy destroyEnemy)
    {
        _destroyEnemy = destroyEnemy;
    }
    public TaskList(AssemblePeasant assemblePeasant)
    {
        _assemblePeasant = assemblePeasant;
    }
    public TaskList(AssembleSoldiers assembleSoldiers)
    {
        _assembleSoldiers = assembleSoldiers;
    }
    public TaskList(CollectGold collectGold)
    {
        _collectGold = collectGold;
    }
    public TaskList()
    {

    }
}
