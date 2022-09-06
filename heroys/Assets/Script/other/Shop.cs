using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Shop : MonoBehaviour,IPointerClickHandler
{
    public Bank Bank;
   public GameObject human;
   public Transform Spawn;
   public Human Human;
   public Text TextCoin;
    public void OnPointerClick(PointerEventData eventData)
    {


    }
    private void FixedUpdate()
    {
    }


}
