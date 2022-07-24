using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(SpawnUndead))]
public class SpawnEditor : Editor
{
    private SpawnUndead _spawnUndead;
    public override void OnInspectorGUI()
    {
        if (_spawnUndead.EnemyObjects.Count > 0)
        {
            foreach (SpawnObject spawnObject in _spawnUndead.EnemyObjects)
            {
                EditorGUILayout.BeginVertical("box");
                if (GUILayout.Button("X",GUILayout.Width(15) ,GUILayout.Height(15)))
                {
                    _spawnUndead.EnemyObjects.Remove(spawnObject);
                    break;
                }
                spawnObject.Image =(Sprite)EditorGUILayout.ObjectField("Картинка", spawnObject.Image, typeof(Sprite), false);
                spawnObject.Name = EditorGUILayout.TextField("Название",spawnObject.Name);
                spawnObject.Undead = EditorGUILayout.ObjectField(spawnObject.Undead, typeof(Undead), true) as Undead;
                spawnObject.Quantity = EditorGUILayout.IntField("Количество",spawnObject.Quantity);
                spawnObject.Time = EditorGUILayout.FloatField("Время", spawnObject.Time);
                spawnObject.IsRepeat = EditorGUILayout.Toggle("Повторять", spawnObject.IsRepeat);
                EditorGUILayout.EndVertical();
            }
        }
        else
        {
            EditorGUILayout.LabelField("Нет элементов");
        }
        if (GUILayout.Button("Добавить"))
        {
            _spawnUndead.EnemyObjects.Add(new SpawnObject());
        }
        if (GUI.changed)
        {
            SetobjectDirty(_spawnUndead.gameObject);
        }
    }
    private void OnEnable()
    {
        _spawnUndead = (SpawnUndead)target;
    }
    private static void SetobjectDirty(GameObject gameObject)
    {
        EditorUtility.SetDirty(gameObject);
        EditorSceneManager.MarkSceneDirty(gameObject.scene);
    } 
}
