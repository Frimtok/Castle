using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(StateGameUI))]
public class StateGame : MonoBehaviour
{
    private const string NAMESCENEMAP = "GlobalMap";
    private StateGameUI _gameStateUI;
    private void Start()
    {
        _gameStateUI = GetComponent<StateGameUI>();
        Play();
    }
    public void Pause()
    {
        Time.timeScale = 0;
        _gameStateUI.ViewPause();
    }
    public void GoMap()
    {
        Play();
        SceneManager.LoadScene(NAMESCENEMAP);
    }
    public void Play()
    {
        _gameStateUI.ViewPlay();
        Time.timeScale = 1;
    }
}
