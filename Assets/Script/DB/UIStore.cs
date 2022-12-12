using UnityEngine;

namespace Script.DB
{
    public abstract class UIStore<TD> : ScriptableObject where TD : ISqlPK, new()
    {
        public TD data;

        /// <summary>
        /// OnEnable to instantiate the reactive property
        /// </summary>
        public abstract void OnEnable();

        /// <summary>
        /// syncUI True to update the UI as soon as the data is loaded
        /// </summary>
        /// <param name="setReactivePropertiesEqualsToData"></param>
        public async void Load(bool setReactivePropertiesEqualsToData = true)
        {
            data = await SqlDB.Load<TD>(data.Pk);
            if (setReactivePropertiesEqualsToData) SetReactivePropertiesEqualToData();
        }

        /// <summary>
        /// Data = Reactive Property Data
        /// </summary>
        public abstract void SetDataEqualToReactiveProperties();

        ///  <summary>
        /// Save the data to the database
        /// </summary>
        public void Save(bool setDataEqualToReactiveProperties = true)
        {
            if (setDataEqualToReactiveProperties) SetDataEqualToReactiveProperties();
            SqlDB.Save(data).Forget();
        }


        /// <summary>
        /// Reactive Property Data = Data
        /// </summary>
        public abstract void SetReactivePropertiesEqualToData();

        /// <summary>
        /// Disable reactive listeners
        /// </summary>
        public abstract void OnDisable();
    }
}