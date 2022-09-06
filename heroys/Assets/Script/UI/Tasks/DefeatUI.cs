using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DefeatUI : MonoBehaviour
{
    public const string defeatRu = "Поражение";
    public const string defeatEn = "Defeat";
    [SerializeField] private Text _defeat;
    [Inject] private Translation _translation;

    private void Start()
    {
        if (_translation._language == Translation.Language.ru)
        {
            _defeat.text = defeatRu;
        }
        if (_translation._language == Translation.Language.en)
        {
            _defeat.text = defeatEn;
        }
        _defeat.gameObject.SetActive(false);
    }
    public void ShowDefeat()
    {
        _defeat.gameObject.SetActive(true);
    }
}
