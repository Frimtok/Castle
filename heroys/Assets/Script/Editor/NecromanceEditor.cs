using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(Necromancer))]
public class NecromanceEditor : Editor
{
    private Necromancer _necromancer;

    public override void OnInspectorGUI()
    {
        _necromancer.Health = EditorGUILayout.IntField("Health",_necromancer.Health);
        if (_necromancer.TypeAttacks.Count > 0)
        {
            foreach (TypeAttacks spawnObject in _necromancer.TypeAttacks)
            {
                EditorGUILayout.BeginVertical("box");
                if (GUILayout.Button("X", GUILayout.Width(15), GUILayout.Height(15)))
                {
                    _necromancer.TypeAttacks.Remove(spawnObject);
                    break;
                }
                spawnObject.Image = (Sprite)EditorGUILayout.ObjectField("Картинка", spawnObject.Image, typeof(Sprite), false);
                spawnObject.Name = EditorGUILayout.TextField("Название", spawnObject.Name);
                spawnObject.TypeAttack = EditorGUILayout.ObjectField(spawnObject.TypeAttack, typeof(TypeAttack), true) as TypeAttack;
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
            _necromancer.TypeAttacks.Add(new TypeAttacks());
        }
        if (GUI.changed)
        {
            SetobjectDirty(_necromancer.gameObject);
        }
    }
    private void OnEnable()
    {
        _necromancer = (Necromancer)target;
    }
    private static void SetobjectDirty(GameObject gameObject)
    {
        EditorUtility.SetDirty(gameObject);
        EditorSceneManager.MarkSceneDirty(gameObject.scene);
    }
}
