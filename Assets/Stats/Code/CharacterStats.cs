using System;
using System.Globalization;
using UniRx;
using UnityEngine;

namespace Script.DB
{
    [CreateAssetMenu(fileName = "ScriptableObject", menuName = "CharacterStats", order = 0)]
    public class CharacterStats : ScriptableObject
    {
        public FloatReactiveProperty health;

        private void OnEnable()
        {
            health = new FloatReactiveProperty(100);
        }
    }
}