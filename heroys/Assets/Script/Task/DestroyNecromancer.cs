using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(DestroyNecromancerUI))]
public class DestroyNecromancer : TaskList
{
    [SerializeField] private  Necromancer _undeadBoss;
    private DestroyNecromancerUI _destroyNecromancerUI;
    private const string NAMEVICTORYSCENE = "Victory";

    private void IsDecrement(int health)
    {
        if (health <= 0)
        {
            Win();
        }
    }
    protected override void Win()
    {
       _destroyNecromancerUI.ShowWin();
        Time.timeScale = 0.1f;
        Invoke("Victory", 0.4f);
    }
    private void Victory()
    {
        SceneManager.LoadScene(NAMEVICTORYSCENE);
    }
    private void Start()
    {
       _destroyNecromancerUI = GetComponent<DestroyNecromancerUI>();
        _undeadBoss.OnView += IsDecrement;
    }
    private void OnDisable()
    {
        _undeadBoss.OnView -= IsDecrement;
        
    }
}
