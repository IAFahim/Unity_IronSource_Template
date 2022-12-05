using System.Collections;
using Cysharp.Threading.Tasks;
using SQLite;
using Stats.Code;
using UnityEngine;

namespace Script.DB
{
    public class SqlDB : MonoBehaviour

    {
        public static SQLiteConnection DB;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            DB= new SQLiteConnection(Application.persistentDataPath + "/SqLite.DB");
        }

        public CharacterStats[] characterStatsArray;


        private void Start()
        {
            // foreach (ScriptableObject o in scriptableObjects)
            // {
            //     DB.CreateTableAsync(o.GetType());
            // }

            Debug.Log("QueryAsync1");
            
            DB.CreateTable<CharacterStats>();
            DB.Insert(characterStatsArray[0]);
        }
        
    }
}