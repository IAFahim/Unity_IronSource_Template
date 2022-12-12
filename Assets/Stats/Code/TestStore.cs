using Script.DB;
using Stats.Code.Default;
using UniRx;
using UnityEditor;
using UnityEngine;

namespace Stats.Code
{
    [CreateAssetMenu(fileName = "TestStore", menuName = "UIStore/TestStore", order = 0)]
    public class TestStore : UIStore<TestingData>
    {
        public StringReactiveProperty characterName;
        public FloatReactiveProperty age;

        public override void OnEnable()
        {
            characterName = new StringReactiveProperty(data.Pk);
            age = new FloatReactiveProperty(data.Age);
        }

        public override void SetDataEqualToReactiveProperties()
        {
            data.Pk = characterName.Value;
            data.Age = age.Value;
        }

        
        public override void SetReactivePropertiesEqualToData()
        {
            characterName.Value = data.Pk;
            age.Value = data.Age;
        }
        
        public override void OnDisable()
        {
            age.Dispose();
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
                    if (store != null) store.SetDataEqualToReactiveProperties();
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