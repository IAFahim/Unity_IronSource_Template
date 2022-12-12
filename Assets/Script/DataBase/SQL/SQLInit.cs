using System.IO;
using Cysharp.Threading.Tasks;
using SQLite;
using UnityEngine;

namespace Script.DataBase.SQL
{
    public class SqlDB 
    {
        public static SQLiteAsyncConnection DB;
        private static SqlDB _instance;
        public static SqlDB Instance => _instance ??= new SqlDB();
        private SqlDB()
        {
            var path = Path.Combine(Application.persistentDataPath, "DataBase.db");
            DB = new SQLiteAsyncConnection(path);
        }

        public async UniTaskVoid Save<T>(T item) where T : new()
        {
            await DB.CreateTableAsync<T>();
            await DB.InsertOrReplaceAsync(item);
            
        }

        public async UniTask<T> Load<T>(object pk) where T : new()
        {
            return await DB.GetAsync<T>(pk);
        }
    }
}