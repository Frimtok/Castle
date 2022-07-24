using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(UIDestroyEnemy))]
public class DestroyEnemy : TaskList
{
    [SerializeField] private int _numberLevel;
    [SerializeField] private int _count;
    [SerializeField] private int _nowDead;
    private UIDestroyEnemy _uIDestroyEnemy;
    public static bool _WIN = false;
    private void Start()
    {
        _WIN = false;
        _uIDestroyEnemy = GetComponent<UIDestroyEnemy>();
        _uIDestroyEnemy.ShowDeadAll(_count);
        _uIDestroyEnemy.ShowDeadNow(_nowDead);
         Undead.DeadEnemyEvent += AddDead;
    }

    private void AddDead()
    {
        _nowDead++; 
        _uIDestroyEnemy.ShowDeadNow(_nowDead);
        if (_nowDead >= _count)
        {
            Win();
        }
    }
    public int GetDeadAll()
    {
        return _count;
    }
    public int GetDeadNow()
    {
        return _nowDead;
    }
    private void Nulled()
    {
        _nowDead = 0;
    }

    private void Win()
    {
        Undead.DeadEnemyEvent -= AddDead;
        _WIN = true;
        Nulled();
        _uIDestroyEnemy.ShowWin();
        Time.timeScale = 0.1f;
        StartCoroutine(NestScenes());
        
    }
    private void NextScene()
    {
        PlayerPrefs.SetInt("Level", _numberLevel);
        SceneManager.LoadScene(Global.NameScene);
    }
    private IEnumerator NestScenes()
    {
        yield return new WaitForSeconds(0.2f);
        Time.timeScale = 1f;
        NextScene();
    }
}
