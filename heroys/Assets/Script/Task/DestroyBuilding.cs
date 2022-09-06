using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UIDestroyBuilding))]
public class DestroyBuilding : TaskList
{
    public UndeadBuilding Building;
    private UIDestroyBuilding _uIDestroyBuilding;
    public static bool _WIN = false;

    private void Start()
    {
        _uIDestroyBuilding = GetComponent<UIDestroyBuilding>();
    }

    private void OnEnable()
    {
        Building.OnCastleEvent += OnBuildingDamegaUndead;
    }
    private void OnDisable()
    {
        Building.OnCastleEvent -= OnBuildingDamegaUndead;
    }
    private void OnBuildingDamegaUndead(int health)
    {
        if (health <= 0)
        {
            _uIDestroyBuilding.ShowWin();
            Win();
        }
    }
    
}
