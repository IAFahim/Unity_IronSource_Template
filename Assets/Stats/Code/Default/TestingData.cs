using System;
using Firebase.Firestore;
using Script.DB;
using SQLite;
using UnityEngine;

namespace Stats.Code.Default
{
    [Serializable]
    [FirestoreData]
    public partial class TestingData : ISqlPK
    {
        [field: SerializeField] [PrimaryKey][FirestoreProperty] public string Pk { get; set; } = "Default";
        [field: SerializeField][FirestoreProperty] public float Age { get; set; } = 20;
#if UNITY_EDITOR
        [Multiline] [SerializeField] private string devDescription = "";
#endif
    }
}