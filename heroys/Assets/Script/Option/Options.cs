using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(OptionsUI))]
public class Options : MonoBehaviour
{
    private const string NAMESCENEMENU = "MainMenu";
    public void GoMain()
    {
        SceneManager.LoadScene(NAMESCENEMENU);
    }
}
