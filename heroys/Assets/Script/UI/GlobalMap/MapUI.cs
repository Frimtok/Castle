using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MapUI : MonoBehaviour
{
    [SerializeField]private Image[] _numbersLevel;
    [SerializeField] private Image _levelRu;
    [SerializeField]private Image _levelEn;
    [SerializeField]private Image _startRu;
    [SerializeField]private Image _startEn;
    [SerializeField] private Text _description;
    [SerializeField] private Text _sumbolView;
    private bool _isView;
    [Inject]private Translation _translation;

    public void OnView(Image back)
    {
        if (_isView == false)
        {
            _sumbolView.text = "+";
            back.gameObject.SetActive(false);
            _isView = true;
        }
        else
        {
            _sumbolView.text = "-";
            back.gameObject.SetActive(true);
            _isView = false;
        }
    }

    public void GetDescription(int number)
    {
        if (_translation._language == Translation.Language.ru)
        {
            GetDescriptionRu(number);
        }
        if (_translation._language == Translation.Language.en)
        {
            GetDescriptionEn(number);
        }
    }
    public void ViewNumberLevel(int Maxlevel, int nowLevel)
    {
        for (int i = 0; i < Maxlevel; i++)
        {
            _numbersLevel[i].gameObject.SetActive(false);
            if (i == nowLevel)
            {
                _numbersLevel[nowLevel].gameObject.SetActive(true);
            }
        }
    }
    private void GetDescriptionRu(int number)
    {
        switch (number)
        {
            case 0:
                _description.text = "��� ����� �����������!";
                break;
            case 1:
                _description.text = "��� ����� �������� ����������, ��� ���������� ������ �� ���� �����. � ����������� � ����, ������ �������� �� ����  ������� ����������.";
                break;
            case 2:
                _description.text = "� ������������ ����� �� ����� ����� ������ ������� ��������� � ����� �����. ����� �� �������� � ���.";
                break;
            case 3:
                _description.text = "�������, ��� � ���� ����� ������� ��������, �� ��� ���� �� ��������.";
                break;
            case 4:
                _description.text = "����� ������� ������ ������, ����� ��������� ������.";
                break;
            case 5:
                _description.text = "�� ��������� � ����� ������� ������, � ������ �����. ����� ��� �������� ����� ������.";
                break;
            case 6:
                _description.text = "����� �������. ��� ��������, ��� � ���� ������ ����� ��������, ����� ���������� �� � ��������� ������.";
                break;
            case 7:
                _description.text = "������������� ����� ����������� ������, ����� ��� ���������.";
                break;
            case 8:
                _description.text = "��� ����� �����, �������� �������, ��� ������ ������� ��� �. � ����� ����� �������������� ������ ���� ������.";
                break;
            case 9:
                _description.text = "��� ����� ��������� �������, ����� ��������� ������.";
                break;
            case 10:
                _description.text = "������ �������� ����� ����� � ����� ������ ��������� �����, � ������� ��������� ������, ����� ���� ����������, ��� �������� ����.";
                break;
            case 11:
                _description.text = "����� ����������� ����� ������, ��� ����� ������ � ����� ����������.";
                break;
            case 12:
                _description.text = "��� ��������, ��� �� ������� ����� �����, ��� � ��������� ���������, ������������ ��� � ����, ����� ���� �������.";
                break;
            case 13:
                _description.text = "�� ������� ������ ������� ������� ������, �� ��� ������� ������ ������ �����������, �� ������ �������� ������.";
                break;
            case 14:
                _description.text = "������ ������. �� ����� �� ������ �� ���������� �����, ����� ��������� ���.";
                break;
            case 15:
                _description.text = "��� �� � ����� �� ����� ����������. ����� �����, ���������� � �����.";
                break;
            case 16:
                _description.text = "�� ��������� ����� � ������ ������� ������, ��� ������� ��������� �������� � �����������.";
                break;
                default: 
                _description.text = "���������� �����.";
                break;
        }
    }
    private void GetDescriptionEn(int number)
    {
        switch (number)
        {
            case 0:
                _description.text = "This is a siege being defended!";
                break;
            case 1:
                _description.text = "I need to find the necromancer who sends the undead to our lands. I'm going on my way, the king has sent some infantrymen after me.";
                break;
            case 2:
                _description.text = "In the liberated castle we found new warriors ready to join our army. We need to test them in battle.";
                break;
            case 3:
                _description.text = "They say that ghosts live in these parts, but this does not frighten us.";
                break;
            case 4:
                _description.text = "You need to collect more gold to move on.";
                break;
            case 5:
                _description.text = "We need stronger warriors, I have sent a messenger. New warriors will be delivered to us soon";
                break;
            case 6:
                _description.text = "The warriors have arrived. We were informed that there are a lot of vampires in these places, we need to destroy them and move on.";
                break;
            case 7:
                _description.text = "The crossing point belongs to the undead, you need to capture it.";
                break;
            case 8:
                _description.text = "We need a card, the merchant says he can sell it to us. The inhabitants of these lands have joined our army.";
                break;
            case 9:
                _description.text = "We need to replenish reserves to move on.";
                break;
            case 10:
                _description.text = "The king sent new people and gave the order to capture the castle where the undead are, you need to be careful, it is guarded by lychees.";
                break;
            case 11:
                _description.text = "We need to make our way through the swamp, my warriors are ready for any difficulties.";
                break;
            case 12:
                _description.text = "I was informed that beyond the swamp of the dark lands, where the necromancer is located, reinforcements are on the way, you just need to wait.";
                break;
            case 13:
                _description.text = "Dangerous knights live on the outskirts of the swamp, but the best warriors of the kingdom have been sent to me, we must win.";
                break;
            case 14:
                _description.text = "The swamp is behind. We have reached one of the enemy's structures, we need to destroy it.";
                break;
            case 15:
                _description.text = "So we reached the necromancer's castle. Forward warriors, prepare for the siege.";
                break;
            case 16:
                _description.text = "We destroyed the walls and were able to get inside, we are waiting for the final battle with the necromancer.";
                break;
            default:
                _description.text = "We continue the hike.";
                break;
        }
    }
    private void Start()
    {
        if (_translation._language == Translation.Language.ru)
        {
            _levelEn.gameObject.SetActive(false);
            _startEn.gameObject.SetActive(false);
            _levelRu.gameObject.SetActive(true);
            _startRu.gameObject.SetActive(true);
        }
        if (_translation._language == Translation.Language.en)
        {
            _levelRu.gameObject.SetActive(false);
            _startRu.gameObject.SetActive(false);
            _levelEn.gameObject.SetActive(true);
            _startEn.gameObject.SetActive(true);
        }
    }

}
