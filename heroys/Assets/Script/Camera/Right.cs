using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : MonoBehaviour
{
    private bool _isOver;
    private void OnMouseOver()
    {
            _isOver = true;
    }
    private void OnMouseExit()
    {
            _isOver = false;
    }

    public bool OnIsOver()
    {
        return _isOver;
    }
}
