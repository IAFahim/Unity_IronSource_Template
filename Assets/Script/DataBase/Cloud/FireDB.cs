using Firebase.Extensions;
using Firebase.Firestore;
using Stats.Code.Default;
using UnityEngine;

namespace Script.DataBase.Cloud
{
    public class FireDB
    {
        public FirebaseFirestore App;
        public DocumentReference docRef;
        private static FireDB _instance;
        public static FireDB Instance => _instance ??= new FireDB();

        private FireDB()
        {
            FirebaseFirestore db = FirebaseFirestore.DefaultInstance;

        }
        
        public static void AddData1() {
            
            
            FirebaseFirestore db = FirebaseFirestore.DefaultInstance;

            DocumentReference docRef = db.Collection("users").Document("cc");
            

            TestingData testingData = new TestingData
            {
                Pk = "jel", Age = 10
            };
            docRef.SetAsync(testingData).ContinueWithOnMainThread(task => {
                Debug.Log("Added data to the alovelace document in the users collection.");
            });
        }
        
    }
    
}