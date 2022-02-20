using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;

public class Bank : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]private float _speed;
    [SerializeField]private float _timer;
    [SerializeField]private int _addition;
    [SerializeField]private int _money;
    [SerializeField] private int _startMoney;
    public delegate void MoneySlider(float moneySpeed);
    public delegate void Money(int moneySpeed);
    public event MoneySlider ViewSpeedMoney;
    public event Money  ViewMoney;
    [SerializeField]private SpawnPoint _spawnPoint;
    private bool _isMax;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_isMax)
        {
            AddMoney(_addition);
            StartCoroutine(WaitingAdd());
        }
    }
    private void Start()
    {
        StartCoroutine(WaitingAdd());
        AddMoney(_startMoney);
    }
    private IEnumerator WaitingAdd()
    {
        float timer = 0;
        _isMax = false;
        ViewSpeedMoney?.Invoke(timer);
        while (_isMax == false)
        {
            if (timer >= _timer)
            {
                timer = 0;
                _isMax = true;
                 yield break;
            }
            else
            {
                timer += Time.deltaTime;
                ViewSpeedMoney?.Invoke(timer);
            }
            yield return null;
        }
    }
    private void AddMoney(int addition)
    {
        _money++;
        _money += addition;
        ViewMoney?.Invoke(_money);
    }
    public float GetTimer()
    {
        return _timer;
    }
    public void DecrementMoney(int price)
    {
        _money -= price;
        ViewMoney?.Invoke(_money);
        Debug.Log(_money);
    }
    public void AddAddition()
    {
        Debug.Log("a");
        _addition++;
    }
    public int GetMoney() => _money;
}

