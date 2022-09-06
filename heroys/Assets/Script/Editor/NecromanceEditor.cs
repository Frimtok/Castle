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
                spawnObject.Image = (Sprite)EditorGUILayout.ObjectField("��������", spawnObject.Image, typeof(Sprite), false);
                spawnObject.Name = EditorGUILayout.TextField("��������", spawnObject.Name);
                spawnObject.TypeAttack = EditorGUILayout.ObjectField(spawnObject.TypeAttack, typeof(TypeAttack), true) as TypeAttack;
                spawnObject.Time = EditorGUILayout.FloatField("�����", spawnObject.Time);
                spawnObject.IsRepeat = EditorGUILayout.Toggle("���������", spawnObject.IsRepeat);
                EditorGUILayout.EndVertical();
            }
        }
        else
        {
            EditorGUILayout.LabelField("��� ���������");
        }
        if (GUILayout.Button("��������"))
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
