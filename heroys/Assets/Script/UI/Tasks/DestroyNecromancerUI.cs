using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyNecromancerUI : UITasks
{
    private const string NAMETASKRU = "”ничтожить некроманта";
    private const string NAMETASKEN = "Destroy the necromancer";

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
}
