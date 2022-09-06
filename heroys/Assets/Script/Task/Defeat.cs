using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(DefeatUI))]

public class Defeat : MonoBehaviour
{
    [SerializeField] private HumanBuilding _humanBuilding;
    private DefeatUI _defeatUi;

    private void OnEnable()
    {
        _humanBuilding.OnCastleEvent += defeat;
    }
    private void Start()
    {
        _defeatUi = GetComponent<DefeatUI>();
    }

    private void defeat(int health)
    {
        if (health <= 0)
        {
            _defeatUi.ShowDefeat();
            Time.timeScale = 0.1f;
            Invoke("NextScene", 0.4f);
        }
    }
    private void NextScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(Global.NameMapScene);
    }
}
