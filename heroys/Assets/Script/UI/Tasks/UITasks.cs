using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
public class UITasks : MonoBehaviour
{
    [SerializeField] private Text _win;
    [SerializeField] private Text _conditionTask;
    public const string winRu = "Победа";
    public const string winEn = "Win";
    [Inject] protected Translation _translation;

    protected void HideTaskUI()
    {
        if (_translation._language == Translation.Language.ru)
        {
            _win.text = winRu;
        }
        if (_translation._language == Translation.Language.en)
        {
            _win.text = winEn;
        }
        _win.gameObject.SetActive(false);
    }
    public void ShowWin()
    {
            _win.gameObject.SetActive(true);
    }
    public void ConditionTask(string nameTask)
    {
        _conditionTask.text = nameTask;
    }
    
}
