using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressFiller : MonoBehaviour
{
   public Slider slider;
   public Canvas BarHealth;
   public Castle castle;
    private void Update()
    {
          
            slider.value = castle.Health;
    }
}
