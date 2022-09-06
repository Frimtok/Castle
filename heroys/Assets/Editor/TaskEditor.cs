using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

[CustomEditor(typeof(Task))]
[System.Serializable]
public class TaskEditor : Editor
{
        Task _task = new Task();
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            switch (_task.TypeTask)
            {
                case Task.TypeTasks.destroyBuilding:
                    DrawDestroyBuilding(_task);
                    break;
                case Task.TypeTasks.destroyBoss:
                    DestroyBoss(_task);
                    break;
                case Task.TypeTasks.destroyEnumy:
                    DestroyEnemy(_task);
                    break;
                case Task.TypeTasks.withstand:
                    Withstand(_task);
                    break;
                case Task.TypeTasks.collectGold:
                    DrawCollectionGold(_task);
                    break;
                case Task.TypeTasks.assembleSoldiers:
                    AssembleSoldiers(_task);
                    break;
                case Task.TypeTasks.assemblePeasant:
                    AssemblePeasant(_task);
                    break;
                default:
                    Debug.Log("error: no task");
                    break;

            }
        }
        private void DrawDestroyBuilding(Task task)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("castle");
            task._castleUndead = EditorGUILayout.ObjectField(task._castleUndead, typeof(UndeadBuilding), true) as UndeadBuilding;
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("task");
            task._destroyBuilding = EditorGUILayout.ObjectField(task._destroyBuilding, typeof(DestroyBuilding), true) as DestroyBuilding;
            EditorGUILayout.EndHorizontal();

        }
        private void DestroyBoss(Task task)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Boss");
            task._battlerBoss = EditorGUILayout.ObjectField(task._battlerBoss, typeof(Battler), true) as Battler;
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("task");
            task._destroyBoss = EditorGUILayout.ObjectField(task._destroyBoss, typeof(DestroyNecromancer), true) as DestroyNecromancer;
            EditorGUILayout.EndHorizontal();
        }
        private void DestroyEnemy(Task task)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Enemy");
            task._enemy = EditorGUILayout.ObjectField(task._enemy, typeof(Battler), true) as Battler;

            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Count");
            task._countEnemy = EditorGUILayout.IntField(task._countEnemy);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("task");
            task._destroyEnemy = EditorGUILayout.ObjectField(task._destroyEnemy, typeof(DestroyEnemy), true) as DestroyEnemy;
            EditorGUILayout.EndHorizontal();
        }
        private void Withstand(Task task)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Wait");
            task._wait = EditorGUILayout.FloatField(task._wait);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("task");
            task._withstand = EditorGUILayout.ObjectField(task._withstand, typeof(Withstand), true) as Withstand;
            EditorGUILayout.EndHorizontal();
        }
        private void DrawCollectionGold(Task task)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("gold");
            task._gold = EditorGUILayout.IntField(task._gold);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("task");
            task._collectGold = EditorGUILayout.ObjectField(task._collectGold, typeof(CollectGold), true) as CollectGold;
            EditorGUILayout.EndHorizontal();
        }
        private void AssembleSoldiers(Task task)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Enemy");
            task._soldiers = EditorGUILayout.ObjectField(task._soldiers, typeof(Human), true) as Human;
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Count");
            task._countSoldiers = EditorGUILayout.IntField(task._countSoldiers);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("task");
            task._assembleSoldiers = EditorGUILayout.ObjectField(task._assembleSoldiers, typeof(AssembleSoldiers), true) as AssembleSoldiers;
            EditorGUILayout.EndHorizontal();
        }
        private void AssemblePeasant(Task task)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Count");
            task._peasant = EditorGUILayout.IntField(task._peasant);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("task");
            task._assemblePeasant = EditorGUILayout.ObjectField(task._assemblePeasant, typeof(AssemblePeasant), true) as AssemblePeasant;
            EditorGUILayout.EndHorizontal();
        }

        private void SetDirty(GameObject gameObject)
        {
            EditorUtility.SetDirty(gameObject);
            EditorSceneManager.MarkSceneDirty(gameObject.scene);
        }
}
