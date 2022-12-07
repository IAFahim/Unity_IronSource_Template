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
        public static SQLiteAsyncConnection DB;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            var databasePath = Path.Combine(Application.persistentDataPath, "SqLite.DB");
            DB = new SQLiteAsyncConnection(databasePath);
        }

        public static async UniTaskVoid Save<T>(T item) where T : new()
        {
            await DB.CreateTableAsync<T>();
            await DB.InsertOrReplaceAsync(item);
        }

        public static async UniTask<T> Load<T>(object pk) where T : new()
        {
            return await DB.GetAsync<T>(pk);
        }
    }
}