using UnityEngine;

namespace Stats.Code.Load
{
    public class CommitCharacterStats : MonoBehaviour
    {
        public CharacterStats characterStats;

        public void Commit()
        {
            characterStats.Commit();
        }
    }
}