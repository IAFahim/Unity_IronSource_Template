using System;
using System.Collections.Generic;
using Firebase;
using Firebase.Extensions;
using Firebase.Firestore;
using UnityEngine;

namespace Script.Cloud
{
    public class FireDB : MonoBehaviour
    {
        public FirebaseFirestore App;
        public DocumentReference docRef;
        private void Start()
        {
            AddData1();
        }
        
        public static void AddData1() {
            FirebaseFirestore db = FirebaseFirestore.DefaultInstance;

            DocumentReference docRef = db.Collection("users").Document("cc");
            Dictionary<string, object> user = new Dictionary<string, object>
            {
                { "First", "Ada" },
                { "Last", "Lovelace" },
                { "Born", 1815 },
            };

            var gold = new User
            {
                Name = "dd", Age = 100
            };
            docRef.SetAsync(gold).ContinueWithOnMainThread(task => {
                Debug.Log("Added data to the alovelace document in the users collection.");
            });
        }
        
    }

    [FirestoreData]
    public class User
    {
        [FirestoreProperty]public string Name { get; set; }
        [FirestoreProperty]public int Age { get; set; }
    }
}