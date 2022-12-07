using UniRx;
using UnityEngine;

namespace Script.DB
{
    public abstract class LoadCommitSave<T> : ScriptableObject
    {
        public T data;
#if UNITY_EDITOR
        [Multiline] [SerializeField] private string devDescription = "";
#endif
        public ReactiveProperty<T> state;

        private void OnEnable()
        {
            state = new ReactiveProperty<T>(data);
        }
    }
}