using System;
using Stats.Code.Default;
using UniRx;
using UnityEngine;

namespace Stats.Code
{
    [CreateAssetMenu(fileName = "ScriptableObject", menuName = "CharacterStats", order = 0)]
    public class CharacterStats : ScriptableObject
    {
        public DefaultCharacterStats main;
        
        [Header("Temp")]
        public StringReactiveProperty characterName;
        public FloatReactiveProperty health;
        
        private void OnEnable()
        {
            health=new FloatReactiveProperty(main.Health);
        }
        
    }
}