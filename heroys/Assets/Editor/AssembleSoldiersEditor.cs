using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

[CustomEditor(typeof(AssembleSoldiers))]
[System.Serializable]
public class AssembleSoldiersEditor : Editor
{
    private AssembleSoldiers _assembleSoldiers;
    public override void OnInspectorGUI()
    {
        if (_assembleSoldiers.AssembleObjects.Count > 0)
        {
            foreach (AssembleObject assembleObject in _assembleSoldiers.AssembleObjects)
            {
                EditorGUILayout.BeginVertical("box");
                if (GUILayout.Button("X", GUILayout.Width(15), GUILayout.Height(15)))
                {
                    _assembleSoldiers.AssembleObjects.Remove(assembleObject);
                    break;
                }
                assembleObject.Image = (Sprite)EditorGUILayout.ObjectField("Картинка", assembleObject.Image, typeof(Sprite), false);
                assembleObject.Name = EditorGUILayout.TextField("Название", assembleObject.Name);
                assembleObject.Human = EditorGUILayout.ObjectField(assembleObject.Human, typeof(Human), true) as Human;
                assembleObject.NowQuantity = EditorGUILayout.IntField("Количество сейчас", assembleObject.NowQuantity);
                assembleObject.Quantity = EditorGUILayout.IntField("Количество всего", assembleObject.Quantity);
                assembleObject.IsDone = EditorGUILayout.Toggle("Выполнено", assembleObject.IsDone);
                assembleObject.Level = EditorGUILayout.IntField("level", assembleObject.Level);
                EditorGUILayout.EndVertical();
            }
        }
        else
        {
            EditorGUILayout.LabelField("Нет элементов");
        }
        if (GUILayout.Button("Добавить"))
        {
            _assembleSoldiers.AssembleObjects.Add(new AssembleObject());
        }
        if (GUI.changed)
        {
            SetobjectDirty(_assembleSoldiers.gameObject);
            
        }
    }
    private void OnEnable()
    {
        _assembleSoldiers = (AssembleSoldiers)target;
    }
    private static void SetobjectDirty(GameObject gameObject)
    {
        EditorUtility.SetDirty(gameObject);
        EditorSceneManager.MarkSceneDirty(gameObject.scene);
    }
}
