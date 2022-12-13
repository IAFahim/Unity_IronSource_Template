using DataBase.SQL;
using Firebase.Firestore;
using UnityEngine;

namespace DataBase.Cloud
{
    public abstract class IFireBaseDB<TD> : ISqlDB<TD> where TD : IFirestoreDocumentString, ISqlPrimaryKey, new()
    {
        public FirebaseFirestore DB;
        public DocumentReference docRef;

        public void UploadData()
        {
            DB ??= FirebaseFirestore.DefaultInstance;
            docRef = DB.Document(data.DocumentPath);
            docRef.SetAsync(data).ContinueWith(task => { Debug.Log($"Upload Complete: {task}"); });
        }

        public async void FetchData()
        {
            DB ??= FirebaseFirestore.DefaultInstance;
            if (data.DocumentPath == "")
            {
                Debug.Log($"DocumentPath is empty: {data.DocumentPath}");
                return;
            }
            docRef = DB.Document(data.DocumentPath);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
            var documentPath = data.DocumentPath;
            var primaryKey = data.PrimaryKey;
            if (snapshot.Exists)
            {
                data = snapshot.ConvertTo<TD>();
                data.DocumentPath = documentPath;
                data.PrimaryKey = primaryKey;
            }
            else
            {
                Debug.Log(data.DocumentPath + " does not exist");
            }
        }
    }
}