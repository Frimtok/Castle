using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(VictoryUI))]
public class Victory : MonoBehaviour
{
    private const string NAMESCENEMENU = "MainMenu";
    public void GoMenu()
    {
        SceneManager.LoadScene(NAMESCENEMENU);
    }
}
