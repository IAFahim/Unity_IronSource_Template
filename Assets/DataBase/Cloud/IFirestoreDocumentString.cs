using Firebase.Firestore;

namespace DataBase.Cloud
{
    public interface IFirestoreDocumentString
    {
        /// <summary>
        /// Example: "users/alovelace"
        /// </summary>
        public string DocumentPath{ get; set; }
    }
}