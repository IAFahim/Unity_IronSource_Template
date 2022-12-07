using SQLite;
using UniRx;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Script.DB
{
    public abstract class UIStore<TD> : ScriptableObject where TD : ISqlPK,new()
    {
        public TD data;

        /// <summary>
        /// OnEnable to instantiate the reactive property
        /// </summary>
        public abstract void OnEnable();

        /// <summary>
        /// syncUI True to update the UI as soon as the data is loaded
        /// </summary>
        /// <param name="syncUI"></param>
        public async void Load(bool syncUI = true)
        {
            data = await SqlDB.Load<TD>(data.Pk);
            if (syncUI) SyncUI();
        }

        /// <summary>
        /// Data = Reactive Property Data
        /// </summary>
        public abstract void Commit();

        ///  <summary>
        /// Save the data to the database
        /// </summary>
        public void Save()
        {
            SqlDB.Save(data).Forget();
        }
        

        /// <summary>
        /// Reactive Property Data = Data
        /// </summary>
        public abstract void SyncUI();
        
    }
}