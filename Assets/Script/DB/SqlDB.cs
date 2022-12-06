using System.Collections;
using System.IO;
using Cysharp.Threading.Tasks;
using SQLite;
using Stats.Code;
using Stats.Code.Default;
using UniRx;
using UnityEngine;

namespace Script.DB
{
    public class SqlDB : MonoBehaviour

    {
        private static SQLiteAsyncConnection _db;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            var databasePath = Path.Combine(Application.persistentDataPath, "SqLite.DB");
            _db = new SQLiteAsyncConnection(databasePath);
        }

        public CharacterStats[] characterStatsArray;

        public async UniTaskVoid Start()
        {
            characterStatsArray[0].main = await Load<DefaultCharacterStats>(characterStatsArray[0].main.Pk);
            characterStatsArray[0].health.Value = characterStatsArray[0].main.Health;
        }

        private async UniTask Save<T>(T item) where T : new()
        {
            await _db.CreateTableAsync<T>();
            await _db.InsertOrReplaceAsync(item);
        }

        private async UniTask<T> Load<T>(string pk) where T : new()
        {
            return await _db.GetAsync<T>(pk);
        }
    }
}