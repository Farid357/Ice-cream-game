using UnityEditor.SceneManagement;
using UnityEditor;
using UnityEngine;
using IceCream.Achievement;
using Zenject;

namespace IceCream.Editor
{
    [System.Serializable]
    public sealed class AchievementEditor : EditorWindow
    {
        private AchievementPresenter _prefab;
        private Transform _parent;
        private readonly StyleCreator _style = new();
        private GUIStyle _labelStyle;
        private GUIStyle _textStyle;
        private string _text;
        private int _goldCount;
        private int _needCount;

        [MenuItem("Window/Achievement editor")]
        public static void Create()
        {
            var window = GetWindow<AchievementEditor>();
            window.Show();
        }

        private void OnGUI()
        {
            SetStyles();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.Space(30);
            EditorGUILayout.LabelField("Создание достижений", _labelStyle);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space(8);
            EditorGUILayout.LabelField("Префаб", _textStyle);
            _prefab = (AchievementPresenter)EditorGUILayout.ObjectField(_prefab, typeof(AchievementPresenter), false);
            EditorGUILayout.Space(30);
            EditorGUILayout.LabelField("Родитель", _textStyle);
            _parent = (Transform)EditorGUILayout.ObjectField(_parent, typeof(Transform), true);
            EditorGUILayout.Space(15);
            EditorGUILayout.LabelField("Текст", _textStyle);
            _text = EditorGUILayout.TextField(_text);
            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Награда (очки)", _textStyle);
            EditorGUILayout.Space(15);
            _goldCount = EditorGUILayout.IntField(_goldCount);
            EditorGUILayout.LabelField("Нужное количество", _textStyle);
            EditorGUILayout.Space(20);
            _needCount = EditorGUILayout.IntField(_needCount);
            EditorGUILayout.Space(20);

            if (GUILayout.Button("Создать"))
            {
                var presenter = Instantiate(_prefab, _parent);
                presenter.Init(_text, _goldCount, _needCount);
                SetDirty(presenter, "AchievementInit");
            }

            if (GUI.changed)
            {
                SetDirty(this, "Modify");
            }
        }

        private void SetDirty<T>(T recordObject, string modify) where T : Object
        {
            Undo.RecordObject(recordObject, modify);
            EditorUtility.SetDirty(recordObject);
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }

        private void SetStyles()
        {
            _labelStyle ??= _style.CreateLabelStyle();
            _textStyle ??= _style.CreateTextStyle();
        }
    }
}
