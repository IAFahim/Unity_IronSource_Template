using UnityEngine;

namespace DataBase.SQL
{
    public abstract class ISqlDB<TD> : ScriptableObject where TD : ISqlPrimaryKey, new()
    {
        public TD data;

        /// <summary>
        /// OnEnable to instantiate the reactive property
        /// </summary>
        public abstract void OnEnable();

        /// <summary>
        /// Reactive Property Data = Data
        /// </summary>
        public abstract void SetReactivePropertiesEqualToData();


        /// <summary>
        /// Data = Reactive Property Data
        /// </summary>
        public abstract void SetDataEqualToReactiveProperties();


        /// <summary>
        /// syncUI True to update the UI as soon as the data is loaded
        /// </summary>
        /// <param name="setReactivePropertiesEqualToData"></param>
        public async void Load(bool setReactivePropertiesEqualToData = true)
        {
            data = await SqlDB.Instance.Load<TD>(data.PrimaryKey);
            if (setReactivePropertiesEqualToData) SetReactivePropertiesEqualToData();
        }

        ///  <summary>
        /// Save the data to the database
        /// </summary>
        public void Save(bool setDataEqualToReactiveProperties = true)
        {
            
            if (setDataEqualToReactiveProperties) SetDataEqualToReactiveProperties();
            Debug.Log("Saving: "+data);
            SqlDB.Instance.Save(data).Forget();
        }


        /// <summary>
        /// Disable reactive listeners
        /// </summary>
        public abstract void OnDisable();
    }
}