using System;
using SQLite;
using UnityEngine;

namespace Stats.Code.Default
{
    [Serializable]
    [Table("Stats")]
    public class MainCharacterStats
    {
        [PrimaryKey] [field: SerializeField] public string CharacterName { get; set; } = "hello";
        [field: SerializeField] public float Health { get; set; }

#if UNITY_EDITOR 
        [Multiline] public string developerDescription = "";
#endif
    }
}