using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssembleSoldiersUI : UITasks
{
    [SerializeField] private Text[] _nowCount;
    [SerializeField] private Text[] _compliteCount;
    [SerializeField] private Image[] _soldateImage;
    private const string NAMETASKRU = "ׁמבונטעו במיצמג:";
    private const string NAMETASKEN = "gather the fighters:";
    public void GetSoldate(int numberHuman, int count, int nowCount)
    {
            _compliteCount[numberHuman].text = count.ToString();
            _nowCount[numberHuman].text = nowCount.ToString() + "  /  ";
    }
    private void Start()
    {
      HideTaskUI();
        if (_translation._language == Translation.Language.en)
        {
            ConditionTask(NAMETASKEN);
        }
        if (_translation._language == Translation.Language.ru)
        {
            ConditionTask(NAMETASKRU);
        }
    }
}
