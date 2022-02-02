using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    public Bank Bank;
    Appearance Appearance;
    public Castle Castle;
    public Castle Castleunded;
    public TypePurpose purpose;
    private int _accumulation;
    private int _finalWave;
    public GameObject Victory;
    public GameObject Defeat;
public enum TypePurpose
    {
        Accumulation,
        Destroy,
        Withstand
    }
    private void Start()
    {
        Victory.gameObject.SetActive(false);
        Defeat.gameObject.SetActive(false);
    }
    private void Accumulation()
    {
        if (Bank.Money == _accumulation)
        {
            Win();
        }
    }
    private void Destroy()
    {
    }

    private void Withstand()
    {
        if (Appearance.Wave == _finalWave)
        {

        }
    }
    private void Win()
    {
        Victory.gameObject.SetActive(true);
    }
    private void Loss()  
    {
        Defeat.gameObject.SetActive(true);
    }
    private void FixedUpdate()
    {
        switch (purpose)
        {
            case TypePurpose.Accumulation:
                Accumulation();
                break;
            case TypePurpose.Destroy:
                Destroy();
                break;
            case TypePurpose.Withstand:
                Withstand();
                break;
        }
    }
}
