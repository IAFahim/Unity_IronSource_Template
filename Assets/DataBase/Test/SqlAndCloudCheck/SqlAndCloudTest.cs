using System;
using DataBase.Cloud;
using DataBase.SQL;
using Firebase.Firestore;
using SQLite;
using UnityEngine;

namespace DataBase.Test.SqlAndCloudCheck
{
    [CreateAssetMenu(fileName = "SqlAndCloudCheck", menuName = "ScriptableObject/SqlAndCloudCheck", order = 0)]
public class SqlAndCloudTest : ISqlDB<SqlAndCloudCheckData>
    {

        public override void OnEnable()
        {

        }

        public override void SetReactivePropertiesEqualToData()
        {
            
        }

        public override void SetDataEqualToReactiveProperties()
        {
            
        }

        public override void OnDisable()
        {
            
        }
    }
    [FirestoreData]
    [Serializable]
    public class SqlAndCloudCheckData : IFirestoreDocumentString, ISqlPrimaryKey
    {
        [PrimaryKey][field:SerializeField] public string PrimaryKey { get; set; } = "Kamal";
        [Ignore][field:SerializeField]public string DocumentPath { get; set; }
        
        [FirestoreProperty]
        [field:SerializeField]
        public int Age { get; set; }

    }
}