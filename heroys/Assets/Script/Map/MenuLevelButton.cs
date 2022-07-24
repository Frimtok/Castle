using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLevelButton : MonoBehaviour
{

    public delegate void Levels();
    public static event Levels EventBackLevels;
    public static event Levels EventNextLevels;
    public static event Levels EventStartLevels;
    public void ClickBack()
    {
        EventBackLevels?.Invoke();
    }
    public void ClickNext()
    {
        EventNextLevels?.Invoke();
    }
    public void ClickStart()
    {
        EventStartLevels?.Invoke();
    }
    
}
