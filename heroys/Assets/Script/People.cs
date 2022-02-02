using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class People : MonoBehaviour,IPointerClickHandler
{
   public Bank Bank;
   public Text TextCoin;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Bank.Money >= Bank.CostPeople && Bank.People < Bank.MaxPeople)
        {
            Bank.Money -= Bank.CostPeople;
            Bank.People++;
        }

    }
    private void FixedUpdate()
    {
        TextCoin.text = $"{Bank.CostPeople}";
    }
}
