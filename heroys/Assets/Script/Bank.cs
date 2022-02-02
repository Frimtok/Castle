using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Bank : MonoBehaviour, IPointerClickHandler
{
    public Text textPeople;
    public int People = 5;
    private bool _accept;
    private float Speed = 1f;
    public int CostPeople;
    public float TimeAccept;
    public Slider ProgressBar;
    private Canvas CanvasBar;
    public int MaxPeople;
    public int Money = 10;
    public Text TextMoney;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_accept)
        {
            _accept = false;
            ProgressBar.value = 0;
            Money += People;
            Invoke("TaxCollection", TimeAccept);
        }
    }
    private void Start()
    {
        TimeAccept = 4;
        _accept = false;
        ProgressBar.value = 0;
        Invoke("TaxCollection", TimeAccept);
    }
    private void FixedUpdate()
    {
        TextMoney.text = $"{Money}";
        textPeople.text = $"{People} / {MaxPeople}";
        ProgressBar.value += Speed * Time.deltaTime;
    }
    private void TaxCollection()
    {
        Debug.Log("i nalog");
        _accept = true;
        
    }

    private void AddPeople()
    {
        if (Money >= CostPeople)
        {
            People++;
        }
    }
}

