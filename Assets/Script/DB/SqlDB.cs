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
        public static SQLiteConnection DB;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            DB = new SQLiteConnection(Application.persistentDataPath + "/SqLite.DB");
        }

        public CharacterStats[] characterStatsArray;

        public async UniTaskVoid Start()
        {
            await AddCustomerAsync(characterStatsArray[0].main);
        }

        private async UniTask AddCustomerAsync(MainCharacterStats mainCharacterStats)
        {
            var databasePath = Path.Combine(Application.persistentDataPath, "SqLite.DB");
            var db = new SQLiteAsyncConnection(databasePath);
            
            await db.CreateTableAsync<MainCharacterStats> ();
            db.InsertOrReplaceAsync(mainCharacterStats);
        }
        
    }
}