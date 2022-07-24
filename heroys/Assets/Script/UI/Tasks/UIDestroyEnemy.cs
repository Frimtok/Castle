using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDestroyEnemy : MonoBehaviour
{
    [SerializeField] private Text _nowDead;
    [SerializeField] private Text _countDead;
    [SerializeField] private Text _win;
    public const string winRu = "Победа";
    public const string NameRu = "Уничтожено врагов:";
    public const string NameEng = "Destroy Enemys:";


    private void Start()
    {
        _win.text = winRu;
        _win.gameObject.SetActive(false);
    }
    public void ShowWin()
    {
        if (_nowDead.IsDestroyed() == false)
        {
            _win.gameObject.SetActive(true);
        }
    }
    public void ShowDeadNow(int deadEnemy)
    {
        if (_nowDead != null)
        {
            _nowDead.text = $"{deadEnemy} / ";
        }
    }
    public void ShowDeadAll(int deadAllEvemy)
    {
        if (_nowDead != null)
        {
             _countDead.text = $"{deadAllEvemy}";
        }
    }
    
}
