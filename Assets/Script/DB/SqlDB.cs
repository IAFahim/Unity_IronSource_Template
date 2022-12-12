using System;
using System.Collections.Generic;
using System.IO;
using Cysharp.Threading.Tasks;
using SQLite;
using Stats.Code;
using Stats.Code.Default;
using UnityEngine;
using UnityEngine.Serialization;
using Object = System.Object;

namespace Script.DB
{
    public class SqlDB : MonoBehaviour
    {
        public static SQLiteAsyncConnection DB;
        private static SqlDB _instance;
        public static SqlDB Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<SqlDB>();
                }
                return _instance;
            }
        }
        
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                var databasePath = Path.Combine(Application.persistentDataPath, "SqLite.DB");
                DB = new SQLiteAsyncConnection(databasePath);
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
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