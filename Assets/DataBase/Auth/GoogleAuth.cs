using System;
using System.Threading.Tasks;
using Firebase;
using Google;
using TMPro;
using UnityEngine;

namespace DataBase.Auth
{
    public class GoogleAuth : MonoBehaviour
    {
        public TextMeshProUGUI text;

        private Firebase.DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;
        private GoogleSignInConfiguration googleSignInConfiguration;
        Firebase.Auth.FirebaseAuth auth;
        Firebase.Auth.FirebaseUser user;

        private void Awake()
        {
            googleSignInConfiguration = new GoogleSignInConfiguration
            {
                WebClientId = "557262155384-m95fvig6gq6alnfgsgppdt0f9fi0pprr.apps.googleusercontent.com",
                RequestIdToken = true
            };
        }

        private void Start()
        {
        }

        private void InitFirebase()
        {
            auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        }

        public void GoogleSign()
        {
            GoogleSignIn.Configuration = googleSignInConfiguration;
            GoogleSignIn.Configuration.UseGameSignIn = false;
            GoogleSignIn.Configuration.RequestIdToken = true;
            GoogleSignIn.DefaultInstance.SignIn().ContinueWith(OnAuthenticationFinished);
        }

        private void OnAuthenticationFinished(Task<GoogleSignInUser> obj)
        {
            text.text="OnAuthenticationFinished";
        }
    }
}