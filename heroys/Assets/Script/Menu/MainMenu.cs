using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(MainMenuUI))]
public class MainMenu : MonoBehaviour
{
    private const string NAMESCENEMAP = "GlobalMap";
    private const string NAMESCENEOPTIONS = "Options";
    public void GoPlay()
    {
        SceneManager.LoadScene(NAMESCENEMAP);
    }
    public void GoOptions()
    {
       SceneManager.LoadScene(NAMESCENEOPTIONS);
    }
    public void GoExit()
    {
        Application.Quit();
    }
}
