using SQLite;
using Stats.Code;
using UnityEngine;

namespace Script.DB
{
    
    public class SqlDB : MonoBehaviour {
        private static SqlDB _instance;
        public SQLiteAsyncConnection DB;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            } else {
                DB=new SQLiteAsyncConnection(Application.persistentDataPath + "/SqLite.DB");
                _instance = this;
            }
        }
        
        private void Start()
        {
            Customer customer=new Customer();
            DB.CreateTableAsync<Customer>();
            DB.InsertAsync(customer);
        }
    }
}