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
      if (Bank.Money >= Human.Cost)
      {
        Bank.Money -= Human.Cost;
        Instantiate(human, Spawn.position, transform.rotation);
      }

    }
    private void FixedUpdate()
    {
        TextCoin.text = $"{Human.Cost}";
    }


}
