using UnityEngine;

public class Global : MonoBehaviour
{
    [SerializeField]private int NowLavel;
    public const string NameMapScene = "GlobalMap";
    
    private void AddLevel()
    {
        NowLavel++;
    }
    private void BackLevel()
    {
        NowLavel--;
    }
    public int GetLevel()
    {
        Debug.Log(NowLavel);
        return NowLavel;
    }
    public void ViewNowLevel()
    {
        Debug.Log(NowLavel);
    }
    private void OnEnable()
    {
        MenuLevelButton.EventNextLevels += AddLevel;
        MenuLevelButton.EventBackLevels += BackLevel; 
    }


}
