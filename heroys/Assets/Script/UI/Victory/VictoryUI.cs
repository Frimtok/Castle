using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class 
    VictoryUI : MonoBehaviour
{
    [SerializeField] private Text _textvictory;
    [Inject] private Translation _translation;
    private void Start()
    {
        if (_translation._language == Translation.Language.en)
        {
            _textvictory.text = "The magician dissolves into thin air, and his amulet breaks into small pieces." +
                "The darkness dissipates and you return to the king with victory.";
        }
        if (_translation._language == Translation.Language.ru)
        {
            _textvictory.text = "��� ����������� � �������, � ��� ������ ����������� �� ��������� �����." +
                "���� ������������ � �� ������������� � ������� � ������.";

        }
    }
}
