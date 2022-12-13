using System;
using DataBase.SQL;
using Firebase.Firestore;
using SQLite;
using UnityEngine;

namespace Stats.Code.Default
{
    [Serializable]
    [FirestoreData]
    public class TestingData : ISqlPrimaryKey
    {
        [field: SerializeField] public string PrimaryKey { get; set; } = "Default";
        [field: SerializeField][FirestoreProperty] public float Age { get; set; } = 20;
#if UNITY_EDITOR
        [Multiline] [SerializeField] private string devDescription = "";
#endif
    }
}