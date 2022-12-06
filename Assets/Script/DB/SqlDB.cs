using System.Collections;
using System.IO;
using Cysharp.Threading.Tasks;
using SQLite;
using Stats.Code;
using Stats.Code.Default;
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
            await Save(characterStatsArray[0].main);
        }

        private async UniTask Save<T> (T item) where T : new()
        {
            await _db.CreateTableAsync<T>();
            await _db.InsertOrReplaceAsync(item);
        }
        
    }
}