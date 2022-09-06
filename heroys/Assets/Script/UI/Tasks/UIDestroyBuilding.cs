using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDestroyBuilding : UITasks
{
    private const string NAMETASKRU = "”ничтожить постройку";
    private const string NAMETASKEN = "Destroy the building";

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
