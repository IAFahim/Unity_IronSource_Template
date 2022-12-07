
using UnityEngine;

namespace Stats.Code.Load
{
    public class LoadCharacterStats : MonoBehaviour
    {
        public CharacterStats characterStats;
        
        public void Load()
        {
            characterStats.Load(true);
        }
        
        // public IEnumerator QueryAsync () => UniTask.ToCoroutine(async () => 
        // {
        //     characterStats.Save();
        // });
    }
}