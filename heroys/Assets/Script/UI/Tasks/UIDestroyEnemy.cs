using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDestroyEnemy : UITasks
{
    [SerializeField] private Text _nowDead;
    [SerializeField] private Text _countDead;
    public const string NAMETASKRU = "”ничтожено врагов:";
    public const string NAMETASKEN = "Destroy Enemys:";
    private void Start()
    {
        HideTaskUI();
        if (_translation._language == Translation.Language.ru)
        {
            ConditionTask(NAMETASKRU);
        }
        if (_translation._language == Translation.Language.en)
        {
            ConditionTask(NAMETASKEN);
        }
    }
    public void ShowDeadNow(int deadEnemy)
    {
        if (_nowDead != null)
        {
            _nowDead.text = $"{deadEnemy} / ";
        }
    }
    public void ShowDeadAll(int deadAllEvemy)
    {
        if (_nowDead != null)
        {
             _countDead.text = $"{deadAllEvemy}";
        }
    }
    
}
