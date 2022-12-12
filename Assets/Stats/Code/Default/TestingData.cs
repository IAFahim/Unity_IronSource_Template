using System;
using Script.DB;
using SQLite;
using UnityEngine;

namespace Stats.Code.Default
{
    [Serializable]
    public partial class TestingData : ISqlPK
    {
        [field:SerializeField]
        
        [PrimaryKey]
        public string Pk { get; set; }="Default";
        [field:SerializeField]
        public float Age{ get; set; } = 20;
#if UNITY_EDITOR
        [Multiline] [SerializeField] private string devDescription = "";
#endif
    }
}