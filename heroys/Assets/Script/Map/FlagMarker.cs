using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagMarker : MonoBehaviour
{
    public  int MaxLevel;
    [SerializeField]private int _nowLevel;
    [SerializeField] private Level[] _pivots;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Level"))
        {
            if (PlayerPrefs.GetInt("Level") > MaxLevel)
            {
                MaxLevel = PlayerPrefs.GetInt("Level");

            }
        }
        else
        {
            Debug.Log("error index");
            MaxLevel = 0;
        }
        _nowLevel = MaxLevel;
        GoOver();
    }
    private void GoOver()
    {
        for (int i = 0; i < _pivots.Length; i++)
        {
            if (i == _nowLevel)
            {
                    transform.position = new Vector2(_pivots[i].transform.position.x, _pivots[i].transform.position.y);
            }
        }
    }
    private void AddLevel()
    {
        if (_nowLevel < MaxLevel)
        {
            _nowLevel++;
            GoOver();
        }
    }
    private void BackLevel()
    {
        if (_nowLevel > 0)
        {
            _nowLevel--;
            GoOver();
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
