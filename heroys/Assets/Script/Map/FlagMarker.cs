using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(MapUI))]
public class FlagMarker : MonoBehaviour
{
    [SerializeField]private  int CompletedLevel;
    [SerializeField]private int _nowLevel;
    [SerializeField] private Level[] _pivots;
    private MapUI _mapUI;

    private void Start()
    {
        OnPlayerPrefs();
        _mapUI = GetComponent<MapUI>();
        _nowLevel = CompletedLevel;
        GoOver(_nowLevel);
        _mapUI.ViewNumberLevel(_pivots.Length, _nowLevel);
    }
    public void GoToButton(int level)
    {
        if (CompletedLevel >= level)
        {
            _nowLevel = level;
            GoOver(_nowLevel);
            _mapUI.GetDescription(_nowLevel);
            _mapUI.ViewNumberLevel(_pivots.Length, _nowLevel);
        }
    }
    private void GoOver(int level)
    {
        transform.position = new Vector2(_pivots[level].transform.position.x, _pivots[level].transform.position.y);
        _mapUI.GetDescription(_nowLevel);
    }
    private void OnPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
                CompletedLevel = PlayerPrefs.GetInt("Level");
        }
        else
        {
            Debug.Log("error index");
            CompletedLevel = 0;
        }
    }
    private void AddLevel()
    {
        if (_nowLevel < CompletedLevel)
        {
            _nowLevel++;
            GoOver(_nowLevel);
            _mapUI.ViewNumberLevel(_pivots.Length, _nowLevel);
        }
    }
    private void BackLevel()
    {
        if (_nowLevel > 0)
        {
            _nowLevel--;
            GoOver(_nowLevel);
            _mapUI.ViewNumberLevel(_pivots.Length, _nowLevel);
        }
    }
    private void StartLevel()
    {
        SceneManager.LoadScene(_pivots[_nowLevel].GetName());
    }
    private void OnEnable()
    {
        MenuLevelButton.EventNextLevels += AddLevel;
        MenuLevelButton.EventStartLevels += StartLevel;
        MenuLevelButton.EventBackLevels += BackLevel;
    }


}
