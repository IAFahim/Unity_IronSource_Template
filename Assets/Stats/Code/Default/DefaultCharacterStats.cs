using System;
using SQLite;
using Unity.VisualScripting;
using UnityEngine;

namespace Stats.Code.Default
{
    [Serializable]
    [Table("Stats")]
    public class DefaultCharacterStats
    {
        [PrimaryKey] [field: SerializeField] public string Pk { get; set; } = nameof(DefaultCharacterStats);
        [field: SerializeField] public float Health { get; set; }

        public override string ToString()
        {
            return $"Health: {Health}";
        }

#if UNITY_EDITOR
        [Multiline] private string _developerDescription = "";
#endif
    }
}