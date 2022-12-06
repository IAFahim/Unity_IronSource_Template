using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Stats.Code.Load
{
    public class LoadCharacterStats : MonoBehaviour
    {
        public CharacterStats characterStats;
        
        public void Load()
        {
            characterStats.Load();
            characterStats.TempToMain();
        }
        
        // public IEnumerator QueryAsync () => UniTask.ToCoroutine(async () => 
        // {
        //     characterStats.Save();
        // });
    }
}