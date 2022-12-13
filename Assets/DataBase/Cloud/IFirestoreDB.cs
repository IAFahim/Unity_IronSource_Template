using System;
using DataBase.SQL;
using Firebase.Firestore;
using Unity.VisualScripting;
using UnityEngine;

namespace DataBase.Cloud
{
    public abstract class IFireBaseDB<TD> : ISqlDB<TD> where TD : IFirestoreDocumentString, ISqlPrimaryKey, new()
    {
        public FirebaseFirestore DB;
        public DocumentReference docRef;

        public void UploadData()
        {
            DB = FirebaseFirestore.DefaultInstance;
            docRef = DB.Document(data.DocumentPath);
            docRef.SetAsync(data).ContinueWith(task =>
            {
                Debug.Log("Upload Complete");
            });
        }
    }
}