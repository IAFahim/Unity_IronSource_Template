using UniRx;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

namespace Stats.Code
{
    [CreateAssetMenu(fileName = "ScriptableObject", menuName = "CharacterStats", order = 0)]
    
    public class CharacterStats : ScriptableObject
    {
        public float Health { get; set; }
        
        public ReactiveProperty<float> rHaelth;

        private void OnEnable()
        {
            rHaelth = new FloatReactiveProperty(Health);
            rHaelth.Subscribe(h => { Health = rHaelth.Value; });
        }
    }
}