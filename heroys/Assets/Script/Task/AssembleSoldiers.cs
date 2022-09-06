using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AssembleSoldiersUI))]
public class AssembleSoldiers : TaskList 
{
    public List<AssembleObject> AssembleObjects;
    private int countDone = 0;
    private SpawnPoint spawnPoint;
    private AssembleSoldiersUI _assembleSoldiersUI;
    public void SetNumberLevel(int number)
    {
        _numberLevel = number;
    }
    private void Start()
    {
        _numberLevel = AssembleObjects[0].Level;
        _assembleSoldiersUI = GetComponent<AssembleSoldiersUI>();
        spawnPoint = FindObjectOfType<SpawnPoint>();
        spawnPoint.SpawnHumanEvent += DetermineHuman;

        for (int i = 0; i < AssembleObjects.Count; i++)
        {
            AssembleObjects[i].ID = i;
          _assembleSoldiersUI.GetSoldate(AssembleObjects[i].ID, AssembleObjects[i].Quantity, AssembleObjects[i].NowQuantity);
        }
    }
    private void OnDisable()
    {
        spawnPoint.SpawnHumanEvent -= DetermineHuman;
    }
    private void DetermineHuman(Human human)
    {
        for (int i = 0; i < AssembleObjects.Count; i++)
        {
            if (human == AssembleObjects[i].Human)
            {
                AssembleObjects[i].NowQuantity++;
                _assembleSoldiersUI.GetSoldate(AssembleObjects[i].ID, AssembleObjects[i].Quantity, AssembleObjects[i].NowQuantity);
                CheakQuantity(AssembleObjects[i].NowQuantity, AssembleObjects[i]);
                if (countDone >= AssembleObjects.Count)
                {
                    _assembleSoldiersUI.ShowWin();
                    Win();
                }
            }
        }

    }
    private void CheakQuantity(int quantity, AssembleObject assembleObject)
    {
        if (quantity == assembleObject.Quantity)
        {
            countDone++;
            assembleObject.IsDone = Complited(assembleObject.IsDone);
        }
    }

    private bool Complited(bool isDone)
    {
        return isDone = true;
    }
}
[System.Serializable]
public class AssembleObject
{
    public string Name;
    public Sprite Image;
    public Human Human;
    public int NowQuantity;
    public int Quantity;
    public int ID;
    public bool IsDone;
    public int Level;
}
