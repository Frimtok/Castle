using UnityEngine.UI;
using UnityEngine;
using Zenject;
using TMPro;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _play;
    [SerializeField] private TextMeshProUGUI _optins;
    [SerializeField] private TextMeshProUGUI _exit;

    [Inject] private Translation _translation;

    private void Start()
    {
        if (_translation._language == Translation.Language.en)
        {
            _play.text = "Play";
            _optins.text = "Options";
            _exit.text = "Exit";
        }
        if (_translation._language == Translation.Language.ru)
        {
            _play.text = "Играть";
            _optins.text = "Опции";
            _exit.text = "Выход";
        }
    }
}
