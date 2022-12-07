using System;
using Script.DB;
using SQLite;
using Stats.Code.Default;
using UniRx;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Stats.Code
{
    [CreateAssetMenu(fileName = "UIStore", menuName = "UIStore/Default", order = 0)]
    public class TestStore : UIStore<TestingData>
    {
        public StringReactiveProperty characterName;
        public FloatReactiveProperty age;

        public override void OnEnable()
        {
            characterName = new StringReactiveProperty(data.Pk);
            age = new FloatReactiveProperty(data.Age);
        }

        public override void Commit()
        {
            data.Pk = characterName.Value;
            data.Age = age.Value;
        }


        public override void SyncUI()
        {
            characterName.Value = data.Pk;
            age.Value = data.Age;
        }


#if UNITY_EDITOR
        [CustomEditor(typeof(TestStore), true)]
        public class UIStoreEditor : UnityEditor.Editor
        {
            public override void OnInspectorGUI()
            {
                base.OnInspectorGUI();
                var store = target as TestStore;

                EditorGUILayout.BeginHorizontal();

                if (GUILayout.Button("Load"))
                {
                    if (store != null) store.Load();
                }

                if (GUILayout.Button("Commit"))
                {
                    if (store != null) store.Commit();
                }

                if (GUILayout.Button("Save"))
                {
                    if (store != null) store.Save();
                }

                EditorGUILayout.EndHorizontal();
            }
        }
#endif
    }
}