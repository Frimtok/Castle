using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssemblePeasantUI : UITasks
{
   [SerializeField] private Text _NowPeasant;
   [SerializeField] private Text _NeedPeasant;
    private const string NAMETASKRU = "Нанято крестьян";
    private void Start()
    {
        HideTaskUI();
        ConditionTask(NAMETASKRU);
    }
    public void ViewPeasant(int nowPeasant, int needPeasant )
    {
        _NowPeasant.text = $"{nowPeasant}";
        _NeedPeasant.text = $"/ {needPeasant}";
    }
    
}
