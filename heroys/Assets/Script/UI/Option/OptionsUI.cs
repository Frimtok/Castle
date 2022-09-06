using UnityEngine.UI;
using UnityEngine;
using Zenject;

public class OptionsUI : MonoBehaviour
{
    [SerializeField] private Image _managmentRU;
    [SerializeField] private Image _managmentEN;
    [SerializeField] private Image _languageEN;
    [SerializeField] private Image _languageRU;
    [SerializeField] private Image _authorRU;
    [SerializeField] private Image _authorEn;
    [Inject] private Translation _translation;
    private void Start()
    {
        Localization();
    }
    private void Update()
    {
        Localization();
    }
    private void Localization()
    {
        if (_translation._language == Translation.Language.en)
        {
            _managmentRU.gameObject.SetActive(false);
            _managmentEN.gameObject.SetActive(true);
            _languageEN.gameObject.SetActive(true);
            _languageRU.gameObject.SetActive(false);
            _authorEn.gameObject.SetActive(true);
            _authorRU.gameObject.SetActive(false);
        }
        if (_translation._language == Translation.Language.ru)
        {
            _managmentRU.gameObject.SetActive(true);
            _managmentEN.gameObject.SetActive(false);
            _languageEN.gameObject.SetActive(false);
            _languageRU.gameObject.SetActive(true);
            _authorEn.gameObject.SetActive(false);
            _authorRU.gameObject.SetActive(true);
        }
    }
}
