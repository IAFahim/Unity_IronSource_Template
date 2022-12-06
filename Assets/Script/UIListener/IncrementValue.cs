﻿using Script.DB;
using Stats.Code;
using UnityEngine;

namespace Script.UIListener
{
    public class IncrementValue : MonoBehaviour
    {
        public CharacterStats characterStats;
        
        public void OnClick()
        {
            characterStats.health.Value += 1;
        }
    }
}