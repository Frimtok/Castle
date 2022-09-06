using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif
public class Task : MonoBehaviour
{
   public enum TypeTasks
    {
        destroyBuilding,
        destroyBoss,
        destroyEnumy,
        withstand,
        collectGold,
        assembleSoldiers,
        assemblePeasant
    }
    [Header("Present")]
    [SerializeField]public TypeTasks TypeTask;
    List<GameObject> _tasks = new List<GameObject>();
    public int _gold;
    private int _soldate;
    public UndeadBuilding _castleUndead;
    public Battler _battlerBoss;
    public int _countEnemy;
    public Battler _enemy;
    public float _wait;
    public int _countSoldiers;
    public Human _soldiers;
    public int _peasant;
    public DestroyBuilding _destroyBuilding;
    public AssemblePeasant _assemblePeasant;
    public AssembleSoldiers _assembleSoldiers;
    public CollectGold _collectGold;
    public DestroyNecromancer _destroyBoss;
    public DestroyEnemy _destroyEnemy;
    public Withstand _withstand;
    private void Start()
    {
        switch (TypeTask)
        {
            case TypeTasks.destroyBuilding:
                _destroyBuilding.Building = _castleUndead;
                break;
            case TypeTasks.destroyBoss:
                break;
            case TypeTasks.destroyEnumy:
                break;
            case TypeTasks.withstand:
                break;
            case TypeTasks.collectGold:
                break;
            case TypeTasks.assembleSoldiers:
                break;
            case TypeTasks.assemblePeasant:
                break;
            default:
                break;
        }
    }

}