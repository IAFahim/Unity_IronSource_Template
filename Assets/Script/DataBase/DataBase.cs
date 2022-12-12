using System;
using Firebase.Firestore;
using Script.DataBase.Cloud;
using Script.DataBase.SQL;
using Script.DB;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

namespace Script.DataBase
{
    public static class DataBase
    {
        private static SqlDB sqlDB=SqlDB.Instance;
        private static FireDB fireDB=FireDB.Instance;

        private static void Save<T>() where T : ScriptableObject, new()
        {
            
        }
    }
    
    [Serializable]
    [FirestoreData]
    public class DataBaseTest: ISqlPK {
        [PrimaryKey]
        [FirestoreProperty]
        public string Pk { get; set; }
        [FirestoreProperty]
        public int Gold { get; set; }
    }
}