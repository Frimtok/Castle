using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StateGameUI : MonoBehaviour
{
    [Inject] private Translation _translation;
    [SerializeField] private Text _pause;
    [SerializeField]private Text _returnToMap;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _stopButton;
    [SerializeField] private Button _returnMenuButton;


    private void Start()
    {
        if (_translation._language == Translation.Language.ru)
        {
            _returnToMap.text = "¬вернутьс€ к карте";
        }
        if (_translation._language == Translation.Language.en)
        {
            _returnToMap.text = "Go back to the map";
        }
    }
    public void ViewPlay()
    {
        _pause.gameObject.SetActive(false);
        _playButton.gameObject.SetActive(false);
        _stopButton.gameObject.SetActive(true);
        _returnMenuButton.gameObject.SetActive(false);
    }
    public void ViewPause() 
    {
        _pause.gameObject.SetActive(true);
        _playButton.gameObject.SetActive(true);
        _stopButton.gameObject.SetActive(false);
        _returnMenuButton.gameObject.SetActive(true);
    }
}
