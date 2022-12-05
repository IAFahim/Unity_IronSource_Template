using System.Collections;
using Cysharp.Threading.Tasks;
using SQLite;
using Stats.Code;
using UnityEngine;

namespace Script.DB
{
    public class SqlDB : MonoBehaviour

    {
        public static SQLiteAsyncConnection DB;

        private void Awake()
        {
            DontDestroyOnLoad(this);
            DB ??= new SQLiteAsyncConnection(Application.persistentDataPath + "/SqLite.DB");
        }

        public ScriptableObject[] scriptableObjects;
        

        private void Start()
        {
            // foreach (ScriptableObject o in scriptableObjects)
            // {
            //     DB.CreateTableAsync(o.GetType());
            // }

            QueryAsync1();
            QueryAsync2();
        }
        
        

        public IEnumerator QueryAsync1() => UniTask.ToCoroutine(async () =>
        {
            
            Debug.Log("QueryAsync1");
            SQLiteAsyncConnection connection = DB;
            await connection.CreateTableAsync<Customer>();
            Customer customer = new Customer
            {
                Email = "004"
            };

            await connection.InsertAsync(customer);
        });
        
        public IEnumerator QueryAsync2() => UniTask.ToCoroutine(async () =>
        {
            
            Debug.Log("QueryAsync2");
            SQLiteAsyncConnection connection = DB;
            await connection.CreateTableAsync<Customer>();

            await connection.InsertAsync((scriptableObjects[0] as CharacterStats)?.customer);
        });
    }
}