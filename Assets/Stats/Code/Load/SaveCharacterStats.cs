using UnityEngine;

namespace Stats.Code.Load
{
    public class SaveCharacterStats: MonoBehaviour
    {
        public CharacterStats characterStats;

        public void Save()
        {
            characterStats.Save();
        }
    }
}