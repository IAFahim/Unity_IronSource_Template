using System;
using Cysharp.Threading.Tasks;
using Script.DB;
using SQLite;
using Stats.Code.Default;
using UniRx;
using UnityEngine;

namespace Stats.Code
{
    [CreateAssetMenu(fileName = "ScriptableObject", menuName = "CharacterStats", order = 0)]

    public class CharacterStats : ScriptableObject
    {
        public DefaultCharacterStats data;

        [Header("State")] public StringReactiveProperty characterName;
        public FloatReactiveProperty health;

        private void OnEnable()
        {
            characterName = new StringReactiveProperty(data.Pk);
            health = new FloatReactiveProperty(data.Health);
        }

        public void SyncState()
        {
            health.Value = data.Health;
        }

        public void Commit()
        {
            data.Health = health.Value;
        }

        public void Save()
        {
            SqlDB.Save(data).Forget();
        }

        public async void Load(bool syncState = true)
        {
            data = await SqlDB.Load<DefaultCharacterStats>(data.Pk);
            if (syncState)
            {
                SyncState();
            }
        }
    }
}