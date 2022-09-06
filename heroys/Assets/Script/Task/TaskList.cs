using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskList : MonoBehaviour
{
    private DestroyBuilding _destroyBuilding;
    private Withstand _withstand;
    private DestroyNecromancer _destroyBoss;
    private DestroyEnemy _destroyEnemy;
    private AssemblePeasant _assemblePeasant;
    private AssembleSoldiers _assembleSoldiers;
    private CollectGold _collectGold;
    [SerializeField] protected int _numberLevel;

    public TaskList(DestroyBuilding destroyBuilding)
    {
        _destroyBuilding = destroyBuilding;
    }
    public TaskList(Withstand withstand)
    {
        _withstand = withstand;
    }
    public TaskList(DestroyNecromancer destroyBoss)
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
    protected virtual void Win()
    {
        Time.timeScale = 0.1f;
        Invoke("NextScene", 0.4f);
    }
    private void NextScene()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("Level", _numberLevel);
        SceneManager.LoadScene(Global.NameMapScene);
    }
}
