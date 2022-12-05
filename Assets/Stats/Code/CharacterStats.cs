using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Script.DB;
using SQLite;
using UniRx;
using UnityEngine;

namespace Stats.Code
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